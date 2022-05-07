using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTest_2 : MonoBehaviour
{
    // ���̾�α� 
    [SerializeField]
    private DialogSystem DialogSystem01;
    [SerializeField]
    private DialogSystem DialogSystem02;

    // ������Ʈ
    [Header("���� ȭ��(����X) ���̵���")]
    public Image NT_background;
    [Header("ù��° �ƾ�")]
    public GameObject FirstCut;
    [Header("�ι�° �ƾ�")]
    public GameObject SecondCut;

    // ���̵��� �ð� ����
    float time = 0f;
    float F_time = 1f;

    // ù��° �ƾ�
    SpriteRenderer Valhalla;
    SpriteRenderer Pandora;
    SpriteRenderer Hand;

    // �ι�° �ƾ�
    SpriteRenderer People;
    SpriteRenderer FrontObject;

    private IEnumerator Start()
    {
        // �ʱ�ȭ
        Valhalla = FirstCut.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Pandora = FirstCut.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Hand = FirstCut.transform.GetChild(2).GetComponent<SpriteRenderer>();

        People = SecondCut.transform.GetChild(0).GetComponent<SpriteRenderer>();
        FrontObject = SecondCut.transform.GetChild(1).GetComponent<SpriteRenderer>();

        People.gameObject.SetActive(false);
        FrontObject.gameObject.SetActive(false);

        StartCoroutine(NT_FadeCoroutine());

        // ù��° ��� �б� ����
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // ù��° �ƾ� Fade out
        Valhalla.gameObject.SetActive(false);
        Pandora.gameObject.SetActive(false);
        Hand.gameObject.SetActive(false);


        // �ι�° �ƾ� Set Active
        yield return new WaitForSeconds(3f);
        People.gameObject.SetActive(true);
        FrontObject.gameObject.SetActive(true);

        // �ι�° ��� �б� ����
        yield return new WaitUntil(() => DialogSystem02.UpdateDialog());

        // Intro3 �� ��ȯ
        // SceneManager.LoadScene("Intro3");
    }

    IEnumerator NT_FadeCoroutine()
    {
        NT_background.gameObject.SetActive(true);

        Color alpha = NT_background.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 3, time);
            NT_background.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(1f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            NT_background.color = alpha;
            yield return null;
        }

        NT_background.gameObject.SetActive(false);
        yield return null;

    }

    /* IEnumerator CutS_FadeCoroutine()
    {
        FirstCut.gameObject.SetActive(true);

        Color alpha = Valhalla.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 3, time);
            NT_background.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(1f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            NT_background.color = alpha;
            yield return null;
        }

        NT_background.gameObject.SetActive(false);
        yield return null;

    }*/
}
