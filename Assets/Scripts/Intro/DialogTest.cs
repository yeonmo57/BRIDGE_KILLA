using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogSystem DialogSystem01;
    [SerializeField]
    private DialogSystem DialogSystem02;
    [SerializeField]
    private DialogSystem DialogSystem03;
    [Header("�ǵ����� ����")]
    public GameObject pandoraBox;
    [Header("���� ȭ��(����) ���̵���")]
    public GameObject T_background;
    [Header("���� ȭ��(����X) ���̵���")]
    public Image NT_background;

    Transform tr;
    SpriteRenderer sr;
    float time = 0f;
    float F_time = 1f;

    private IEnumerator Start()
    {
        sr = T_background.GetComponent<SpriteRenderer>();
        float alphaValue = sr.color.a;
        tr = pandoraBox.GetComponent<Transform>();

        StartCoroutine(T_FadeCoroutine(alphaValue));

        // ù��° ��� �б� ����
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // ��� �б� ���̿� ���ϴ� �ൿ �߰� ����
        int count = 3;


        while (count > 0)
        {
            count--;
            yield return new WaitForSeconds(1f);
        }

        // �ι�° ��� �б� ����
        yield return new WaitUntil(() => DialogSystem02.UpdateDialog());

        //���� ȭ�� -> ���̵���
        StartCoroutine(NT_FadeCoroutine());

        // ����° ��� �б� ����
        yield return new WaitUntil(() => DialogSystem03.UpdateDialog());

        StartCoroutine(MoveCoroutine());

    }

    IEnumerator T_FadeCoroutine(float alphaValue)
    {
        while (alphaValue > 0)
        {
            alphaValue -= 0.005f;
            yield return new WaitForSeconds(0.001f);
            sr.color = new Color(0, 0, 0, alphaValue);
        }
    }
    IEnumerator MoveCoroutine()
    {
        for (float i = 0; i >= -20f; i -= 0.2f)
        {
            Debug.Log("1�ʵ�");
            tr.position = new Vector3(i, 0, 0);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    IEnumerator NT_FadeCoroutine()
    {
        NT_background.gameObject.SetActive(true);

        Color alpha = NT_background.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            NT_background.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(1f);

        while(alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            NT_background.color = alpha;
            yield return null;
        }

        NT_background.gameObject.SetActive(false);
        yield return null;

    }
}