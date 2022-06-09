using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTest : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogueSystem;

    private IEnumerator Start()
    {
        // ù ��° ��� �б� ����
        yield return new WaitUntil(() => dialogueSystem.UpdateDialogue());

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Make1");
    }
}
