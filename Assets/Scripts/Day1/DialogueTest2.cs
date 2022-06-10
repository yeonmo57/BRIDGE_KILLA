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
    [Header("���� ȭ��(����X) ���̵���")]
    public Image NT_background;

    public GameObject Kimera;
    public GameObject Michaella;

    // ���̵��� �ð� ����
    float time = 0f;
    float F_time = 1.5f;

    private IEnumerator Start()
    {
        Michaella.SetActive(false);
        StartCoroutine(NT_FadeCoroutine());
        yield return new WaitForSeconds(4);

        // ù ��° ��� �б� ����
        yield return new WaitUntil(() => dialogueSystem01.UpdateDialogue());

        yield return new WaitForSeconds(1);

        // Ű�޶� ����� -> ���Ŀ� ���̵� �ƿ� ȿ��
        Kimera.SetActive(false);

        yield return new WaitForSeconds(2);

        yield return new WaitUntil(() => dialogueSystem02.UpdateDialogue());

        // �ѹ��ѹ� �Ҹ� ���
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        yield return new WaitForSeconds(3);
        audioSource.Stop();

        yield return new WaitUntil(() => dialogueSystem03.UpdateDialogue());

        // ���� ������ SetActive();
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
