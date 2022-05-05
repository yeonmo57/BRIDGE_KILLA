using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogSystem DialogSystem01;
    [SerializeField]
    private DialogSystem DialogSystem02;
    
    private IEnumerator Start()
    {
        // ù��° ��� �б� ����
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // ��� �б� ���̿� 
    }
}
