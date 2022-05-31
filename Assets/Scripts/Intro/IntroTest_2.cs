using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTest_2 : MonoBehaviour
{
    // 다이얼로그 
    [SerializeField]
    private DialogSystem DialogSystem01;
    [SerializeField]
    private DialogSystem DialogSystem02;

    // 오브젝트
    [Header("검은 화면(투명X) 페이드인")]
    public Image NT_background;
    [Header("첫번째 컷씬")]
    public GameObject FirstCut;
    [Header("두번째 컷씬")]
    public GameObject SecondCut;

    // 페이드인 시간 조절
    float time = 0f;
    float F_time = 1f;

    // 첫번째 컷씬
    SpriteRenderer Valhalla;
    SpriteRenderer Pandora;
    SpriteRenderer Hand;

    // 두번째 컷씬
    SpriteRenderer People;
    SpriteRenderer FrontObject;

    private IEnumerator Start()
    {
        // 초기화
        Valhalla = FirstCut.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Pandora = FirstCut.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Hand = FirstCut.transform.GetChild(2).GetComponent<SpriteRenderer>();

        People = SecondCut.transform.GetChild(0).GetComponent<SpriteRenderer>();
        FrontObject = SecondCut.transform.GetChild(1).GetComponent<SpriteRenderer>();

        StartCoroutine(NT_FadeCoroutine());

        // 첫번째 대사 분기 시작
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        // 첫번째 컷씬 Fade out
        StartCoroutine(CutS_FadeCoroutine());

        // 두번째 컷씬 Set Active
        yield return new WaitForSeconds(3f);
        // 두번째 대사 분기 시작
        yield return new WaitUntil(() => DialogSystem02.UpdateDialog());

        // Intro3 씬 전환
        SceneManager.LoadScene("Intro3");
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
        
     IEnumerator CutS_FadeCoroutine()
    {
        Color alphaV = Valhalla.color;
        Color alphaH = Hand.color;
        Color alphaP = Pandora.color;

        Color alphaPE = People.color;
        Color alphaFO = FrontObject.color;

        while (alphaV.a > 0 && alphaH.a > 0 && alphaP.a > 0)
        {
            time += Time.deltaTime /F_time;
            alphaV.a = Mathf.Lerp(1, 0, time);
            alphaH.a = Mathf.Lerp(1, 0, time);
            alphaP.a = Mathf.Lerp(1, 0, time);

            Valhalla.color = alphaV;
            Hand.color = alphaH;
            Pandora.color = alphaP;

            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(3f);

        while (alphaPE.a < 1f && alphaFO.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alphaPE.a = Mathf.Lerp(0, 3, time);
            alphaFO.a = Mathf.Lerp(0, 3, time);

            People.color = alphaPE;
            FrontObject.color = alphaFO;
            yield return null;
        }

        yield return null;

    }
}
