using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerMove : MonoBehaviour
{

    //public GameObject cliff; //바위
    //public GameObject field;
    public float speed = 1.0f;

    //헨젤과 그레텔처럼.. 빵 조각을 따라서 움직입니다.
    [SerializeField] Transform[] cliffPos; //빵조각 배열
    int cliffNum = 0; //빵 인덱스

    [SerializeField] Transform[] fieldPos; 
    int fieldNum = 0; 

    bool move = false;
    bool move_field = false;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = cliffPos[cliffNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            Movecliff();
        }

        if (move_field == true)
        {
            Movefield();
        }
    }

    public void OnclickCliff()
    {
        Debug.Log("Button Click");
        move = true;
    }

    public void OnclickField()
    {
        Debug.Log("Button Click");
        move_field = true;
    }

    public void Movecliff()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, cliffPos[cliffNum].transform.position, speed * Time.deltaTime);

        if (transform.position == cliffPos[cliffNum].transform.position)
        {
            cliffNum++;
        }

        if (cliffNum == cliffPos.Length)
        {
            //해당 씬으로 이동
            move = false;
            Debug.Log("Next Scenes");
        }
    }

    public void Movefield()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, fieldPos[fieldNum].transform.position, speed * Time.deltaTime);

        if (transform.position == fieldPos[fieldNum].transform.position)
        {
            fieldNum++;
        }

        if (fieldNum == fieldPos.Length)
        {
            //해당 씬으로 이동
            move_field = false;
            Debug.Log("Next field Scenes");
        }
    }

}
