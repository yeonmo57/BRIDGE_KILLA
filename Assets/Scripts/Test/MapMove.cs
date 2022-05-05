using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public GameObject house; //1번 째 집
    public float speed = 1.0f;

    [SerializeField] Transform[] loadPos;
    int loadNum = 0;

    bool move = false;

    void Start()
    {
        transform.position = loadPos[loadNum].transform.position;
    }

    void Update()
    {
        if (move == true)
        {
            MovePath();
        }
    }

    public void OnclickPlace1()
    {
        Debug.Log("Button Click");
        //transform.position = Vector2.MoveTowards(transform.position, house.transform.position, speed * Time.deltaTime);
        move = true;
    }

    public void MovePath()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, loadPos[loadNum].transform.position, speed * Time.deltaTime);

        if (transform.position == loadPos[loadNum].transform.position)
        {
            loadNum++;
        }

        if (loadNum == loadPos.Length)
        {
            //해당 씬으로 이동
            move = false;
            Debug.Log("Next Scenes");
        }
    }
}

