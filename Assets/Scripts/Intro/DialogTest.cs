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
    [Header("판도라의 상자")]
    public GameObject pandoraBox;
    [Header("검은 화면(투명) 페이드인")]
    public GameObject T_background;
    [Header("검은 화면(투명X) 페이드인")]
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

        // 첫번째 대사 분기 시작
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // 대사 분기 사이에 원하는 행동 추가 가능
        int count = 3;


        while (count > 0)
        {
            count--;
            yield return new WaitForSeconds(1f);
        }

        // 두번째 대사 분기 시작
        yield return new WaitUntil(() => DialogSystem02.UpdateDialog());

        //검정 화면 -> 페이드인
        StartCoroutine(NT_FadeCoroutine());

        // 세번째 대사 분기 시작
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
            Debug.Log("1초뒤");
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