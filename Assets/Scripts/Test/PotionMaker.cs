using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionMaker : MonoBehaviour
{
    // ���� ��� ����
    public GameObject material1;
    public GameObject material2;
    public GameObject material3;

    public static int count = 0;

    public void Material1()
    {
        // Instantiate(������ ������Ʈ, position, rotation)
        // Quaternion.identity = rotation(ȸ����)�� 0,0,0 ���� �ǹ� (ȸ������)
        Instantiate(material1, new Vector3(3.628f, 2.375f, 0), Quaternion.identity);
        material1.SetActive(true);
        count += 1;

    }

    public void Material2()
    {
        // Instantiate(������ ������Ʈ, position, rotation)
        // Quaternion.identity = rotation(ȸ����)�� 0,0,0 ���� �ǹ� (ȸ������)
        Instantiate(material2, new Vector3(5.104f, 2.396f, 0), Quaternion.identity);
        material2.SetActive(true);
        count += 1;
    }

    public void Material3()
    {
        // Instantiate(������ ������Ʈ, position, rotation)
        // Quaternion.identity = rotation(ȸ����)�� 0,0,0 ���� �ǹ� (ȸ������)
        Instantiate(material3, new Vector3(6.535f, 2.349f, 0), Quaternion.identity);
        material3.SetActive(true);
        count += 1;
    }

}
