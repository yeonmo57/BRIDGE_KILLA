using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoideMaker : MonoBehaviour
{
    //��� ����
    //3��° �ϴû� ��
    public GameObject spoidebottle3;
    public GameObject buttonmake;

    public static int count = 0;

    public void spoide_Bottle3()
    {
        // Instantiate(������ ������Ʈ, position, rotation)
        // Quaternion.identity = rotation(ȸ����)�� 0,0,0 ���� �ǹ� (ȸ������)
        Instantiate(spoidebottle3, new Vector3(5.054f, -0.73f, 0), Quaternion.identity);
        spoidebottle3.SetActive(true);
        count += 1;

        Instantiate(buttonmake, new Vector3(2.68f, -3.17f, 0), Quaternion.identity);
        buttonmake.SetActive(true);
    }

}
