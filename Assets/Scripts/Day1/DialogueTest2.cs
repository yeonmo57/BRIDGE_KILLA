using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTest2 : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogueSystem01;
    [SerializeField]
    private DialogueSystem dialogueSystem02;
    [SerializeField]
    private DialogueSystem dialogueSystem03;
    [SerializeField]
    private DialogueSystem dialogueSystem04;
    [Header("검은 화면(투명X) 페이드인")]
    public Image NT_background;

    public GameObject Kimera;
    public GameObject Michaella;

    // 페이드인 시간 조절
    float time = 0f;
    float F_time = 1.5f;

    private IEnumerator Start()
    {
        Michaella.SetActive(false);
        StartCoroutine(NT_FadeCoroutine());
        yield return new WaitForSeconds(4);

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem01.UpdateDialogue());

        yield return new WaitForSeconds(1);

        // 키메라 사라짐 -> 추후에 페이드 아웃 효과
        Kimera.SetActive(false);

        yield return new WaitForSeconds(2);

        yield return new WaitUntil(() => dialogueSystem02.UpdateDialogue());

        // 뚜벅뚜벅 소리 출력
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        yield return new WaitForSeconds(3);
        audioSource.Stop();

        yield return new WaitUntil(() => dialogueSystem03.UpdateDialogue());

        // 지도 아이콘 SetActive();
        yield return new WaitUntil(() => dialogueSystem04.UpdateDialogue());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Map");
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
}
