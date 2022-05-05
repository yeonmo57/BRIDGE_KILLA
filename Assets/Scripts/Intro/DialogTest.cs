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
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // 대사 분기 사이에 원하는 행동 추가 가능
        int count = 5;
        while(count > 0)
        {
            count--;
            yield return new WaitForSeconds(1f);
        }

        // 두번째 대사 분기 시작
        yield return new WaitUntil(() => DialogSystem02.UpdateDialog());

    }
}
