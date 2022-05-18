using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerMove : MonoBehaviour
{

    //public GameObject cliff; //����
    //public GameObject field;
    public float speed = 1.0f;

    //������ �׷���ó��.. �� ������ ���� �����Դϴ�.
    [SerializeField] Transform[] cliffPos; //������ �迭
    int cliffNum = 0; //�� �ε���

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
            //�ش� ������ �̵�
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
            //�ش� ������ �̵�
            move_field = false;
            Debug.Log("Next field Scenes");
        }
    }

}
