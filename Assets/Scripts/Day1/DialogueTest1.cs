using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTest1 : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogueSystem01;
    [SerializeField]
    private DialogueSystem dialogueSystem02;
    [Header("검은 화면(투명X) 페이드인")]
    public Image NT_background;

    public GameObject Kimera;
    
    Color alpha;


    // 페이드인 시간 조절
    float time = 0f;
    float F_time = 1.5f;

    private IEnumerator Start()
    {

        
        Kimera.SetActive(false);
        StartCoroutine(NT_FadeCoroutine()); 
        yield return new WaitForSeconds(4);

        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem01.UpdateDialogue());

        // 고양이 울음 소리
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        Kimera.SetActive(true);
        yield return new WaitForSeconds(2);

        // 두번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem02.UpdateDialogue());

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Make1");
    }

    IEnumerator NT_FadeCoroutine()
    {
        NT_background.gameObject.SetActive(true);
        alpha = NT_background.color;
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
