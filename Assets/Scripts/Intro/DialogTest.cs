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
        // 첫번째 대사 분기 시작
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // 대사 분기 사이에 
    }
}
