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
        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogueSystem.UpdateDialogue());

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Make1");
    }
}
