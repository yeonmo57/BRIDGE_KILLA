using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; // ��ȭ�� �����ϴ� ĳ���͵��� UI �迭
    [SerializeField]
    private DialogueData[] dialogues; // ���� �б��� ��� ��� �迭
    [SerializeField] 
    private bool isAutoStart = true; // �ڵ� ���� ����
    private bool isFirst = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
    private int currentDialogueIndex = -1; // ���� ��� ����
    private int currentSpeakerIndex = 0; // ���� ���� �ϴ� ȭ���� speakers �迭 ���� 
    private float typingSpeed = 0.1f; // Ÿ���� ȿ�� ��� �ӵ�
    private bool isTypingEffect = false; // �ؽ�Ʈ Ÿ���� ȿ�� ���������

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // ��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ 
        for(int i =0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            // ĳ���� �̹����� ���̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialogue()
    {
        // ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
        if (isFirst)
        {
            // �ʱ�ȭ, ĳ���� �̹����� Ȱ��ȭ, ��� ���� UI ��� ��Ȱ��ȭ
            Setup();
            if (isAutoStart) SetNextDialogue();

            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isTypingEffect)
            {
                isTypingEffect = false;
                // Ÿ���� ȿ�� ����, ���� ��� ��ü ���
                StopCoroutine("OnTypingEffect");
                speakers[currentSpeakerIndex].textDialogue.text = dialogues[currentDialogueIndex].dialogue;
                // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;

            }
            // ��簡 �������� ��� ���� ��� ����
            if(dialogues.Length > currentDialogueIndex + 1)
            {
                SetNextDialogue();
            }
            else
            {
                for(int i =0; i<speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }

                return true;
            }
        }

        return false;
    }

    private void SetNextDialogue()
    {
        // ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        // ���� ��縦 ����
        currentDialogueIndex++;

        // ���� ȭ�� ���� ����
        currentSpeakerIndex = dialogues[currentDialogueIndex].speakerIndex;

        // ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], true);

        // ���� ȭ�� �̸� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textName.text = dialogues[currentDialogueIndex].name;

        // ���� ȭ���� ��� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textDialogue.text = dialogues[currentDialogueIndex].dialogue;

        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageBox.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

        // ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϱ� ������ �׻� false
        speaker.objectArrow.gameObject.SetActive(false);

        // ĳ���� ���İ� ����
        //Color color = speaker.spriteRenderer.color;
        //color.a = visible == true ? 1 : 0.2f;
        //speaker.spriteRenderer.color = color;
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;
        while(index < dialogues[currentDialogueIndex].dialogue.Length)
        {
            speakers[currentSpeakerIndex].textDialogue.text = dialogues[currentDialogueIndex].dialogue.Substring(0, index);
            index++;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }
}

[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer; // ĳ���� �̹���
    public Image imageBox; // ��ȭâ �̹���
    public Text textName; // ���� ������� ĳ���� �̸� ���
    public Text textDialogue; // ���� ��� ���
    public GameObject objectArrow; // Ŀ�� ������Ʈ 
}

[System.Serializable]
public struct DialogueData
{
    public int speakerIndex; // �̸��� ��縦 ����� ���� speaker�� �迭 ����
    public string name; // ĳ���� �̸�
    [TextArea(3, 5)]
    public string dialogue; // ���
}

