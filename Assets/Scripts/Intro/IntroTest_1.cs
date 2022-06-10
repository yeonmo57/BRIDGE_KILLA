using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTest_1: MonoBehaviour
{
    // 다이얼로그 
    [SerializeField]
    private DialogSystem DialogSystem01;
    [SerializeField]
    private DialogSystem DialogSystem02;
    [SerializeField]
    private DialogSystem DialogSystem03;
    [SerializeField]
    private DialogSystem DialogSystem04;

    // 오브젝트 
    [Header("판도라의 상자")]
    public GameObject pandoraBox;
    [Header("검은 화면(투명) 페이드인")]
    public GameObject T_background;
    [Header("검은 화면(투명X) 페이드인")]
    public Image NT_background;
    [Header("발할라 손")]
    public GameObject ValhallaHand;

    
    Transform tr;
    SpriteRenderer sr;
    SpriteRenderer vh;
    float time = 0f;
    float F_time = 1f;

    private IEnumerator Start()
    {
        Screen.SetResolution(1920, 1080, true);
        sr = T_background.GetComponent<SpriteRenderer>();
        float alphaValue = sr.color.a;

        vh = ValhallaHand.GetComponent<SpriteRenderer>();
        float vh_alphaValue = vh.color.a;

        tr = pandoraBox.GetComponent<Transform>();

        // 첫번째 대사 분기 시작
        StartCoroutine(T_FadeCoroutine(alphaValue));
        Debug.Log(alphaValue);
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
        T_background.gameObject.SetActive(false);
        StartCoroutine(NT_FadeCoroutine());

        yield return new WaitForSeconds(2.5f);

        // 세번째 대사 분기 시작
        yield return new WaitUntil(() => DialogSystem03.UpdateDialog());

        // 박스 이동
        StartCoroutine(MoveCoroutine());

        yield return new WaitForSeconds(4.5f);

        // 손 페이드 인
        StartCoroutine(H_FadeCoroutine(vh_alphaValue));

        // 네번째 대사 분기 시작       
        yield return new WaitUntil(() => DialogSystem04.UpdateDialog());

        // Intro2 씬 전환
        SceneManager.LoadScene("Intro2");
    }

    IEnumerator T_FadeCoroutine(float alphaValue)
    {
        while (alphaValue > 0.7)
        {
            alphaValue -= 0.01f;
            yield return new WaitForSeconds(0.05f);
            sr.color = new Color(0, 0, 0, alphaValue);
        }
    }

    // 손 페이드 인
    IEnumerator H_FadeCoroutine(float vh_alphaValue)
    {
        while (vh_alphaValue < 255)
        {
            vh_alphaValue += 0.05f;
            yield return new WaitForSeconds(0.001f);
            vh.color = new Color(255, 255, 255, vh_alphaValue);
        }
    }
    IEnumerator MoveCoroutine()
    {
        for (float i = 0; i >= -15.5f; i -= 0.1f)
        {
            tr.position = new Vector3(i, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
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