using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoideGive : MonoBehaviour
{
    //����ȭ�� ��Ӱ� ó��
    public GameObject blackscreen;

    public void BlackScreen()
    {
        // Instantiate(������ ������Ʈ, position, rotation)
        // Quaternion.identity = rotation(ȸ����)�� 0,0,0 ���� �ǹ� (ȸ������)

        Instantiate(blackscreen, new Vector3(10.02f, 0.07f, 0), Quaternion.identity);
        blackscreen.SetActive(true);
    }
}
