using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public GameObject house; //1�� ° ��
    public float speed = 1.0f;

    //������ �׷���ó��.. �� ������ ���� �����Դϴ�.
    [SerializeField] Transform[] loadPos; //������ �迭
    int loadNum = 0; //�� �ε���

    bool move = false;

    void Start()
    {
        transform.position = loadPos[loadNum].transform.position;
    }

    void Update()
    {
        //Ŭ���ؼ� move�� true�� ����, �������� ���ư� ������ �����̴� �Լ� ȣ��
        if (move == true)
        {
            MovePath();
        }
    }

    //��ư Ŭ���� ����
    public void OnclickPlace1()
    {
        Debug.Log("Button Click");
        //Ŭ���ϸ� move�� true�� ����
        move = true;
    }

    //�����̴� �Լ�
    public void MovePath()
    {
        //��ġ �ٲ�
        transform.position = Vector2.MoveTowards
            (transform.position, loadPos[loadNum].transform.position, speed * Time.deltaTime);

        //���� ��ġ�� �̵��ƴٸ�
        if (transform.position == loadPos[loadNum].transform.position)
        {   
            //���� �� ��ġ �ε����� 
            loadNum++;
        }

        //�迭 ������ �̵��ߴٸ�
        if (loadNum == loadPos.Length)
        {
            //�̵� �Լ� �����ش� (�迭 ������ �Ѿ�� �ʵ���) 
            move = false;
            //�ش� ������ �̵�
            Debug.Log("Next Scenes");
        }
    }
}

