using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public GameObject house; //1번 째 집
    public float speed = 1.0f;

    //헨젤과 그레텔처럼.. 빵 조각을 따라서 움직입니다.
    [SerializeField] Transform[] loadPos; //빵조각 배열
    int loadNum = 0; //빵 인덱스

    bool move = false;

    void Start()
    {
        transform.position = loadPos[loadNum].transform.position;
    }

    void Update()
    {
        //클릭해서 move가 true일 때만, 프레임이 돌아갈 때마다 움직이는 함수 호출
        if (move == true)
        {
            MovePath();
        }
    }

    //버튼 클릭시 실행
    public void OnclickPlace1()
    {
        Debug.Log("Button Click");
        //클릭하면 move를 true로 설정
        move = true;
    }

    //움직이는 함수
    public void MovePath()
    {
        //위치 바꿈
        transform.position = Vector2.MoveTowards
            (transform.position, loadPos[loadNum].transform.position, speed * Time.deltaTime);

        //만약 위치가 이동됐다면
        if (transform.position == loadPos[loadNum].transform.position)
        {   
            //다음 번 위치 인덱스로 
            loadNum++;
        }

        //배열 끝까지 이동했다면
        if (loadNum == loadPos.Length)
        {
            //이동 함수 멈춰준다 (배열 범위를 넘어가지 않도록) 
            move = false;
            //해당 씬으로 이동
            Debug.Log("Next Scenes");
        }
    }
}

