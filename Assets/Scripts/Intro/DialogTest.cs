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
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // ��� �б� ���̿� ���ϴ� �ൿ �߰� ����
        int count = 5;
        while(count > 0)
        {
            count--;
            yield return new WaitForSeconds(1f);
        }

        // �ι�° ��� �б� ����
        yield return new WaitUntil(() => DialogSystem02.UpdateDialog());

    }
}
