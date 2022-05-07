using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker speaker; // ��ȭ�� �����ϴ� ĳ������ UI 
    [SerializeField]
    private DialogData[] dialogs; // ���� �б��� ��� ��� �迭
    [SerializeField]
    private bool isAutoStart = true; // �ڵ� ���� ����
    private bool isFirst = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
    private int currentDialogIndex = -1; // ���� ��� ����
    private float typingSpeed = 0.1f; // �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
    private bool isTypingEffect = false; // �ؽ�Ʈ Ÿ���� ȿ���� ���������


    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // ��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ
        SetActiveObjects(speaker, false);
    }

    public bool UpdateDialog()
    {
        // ��� �бⰡ ���۵� �� 1ȸ�� ����
        if(isFirst == true)
        {   
            // �ʱ�ȭ, ĳ���� �̹��� Ȱ��ȭ, ��� ���� UI ��� ��Ȱ��ȭ
            Setup();

            // �ڵ� ������� �����Ǿ� ������ ù��° ��� ���
            if (isAutoStart) SetNextDialog();

            isFirst = false;
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �ؽ�Ʈ Ÿ���� ȿ���� ������� �� �����̽� ������ Ÿ���� ȿ�� ����
            if (isTypingEffect == true)
            {
                isTypingEffect = false;

                // Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ���
                StopCoroutine("OnTypingText");
                speaker.textDialog.text = dialogs[currentDialogIndex].dialogs;

                // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
                speaker.objectArrow.SetActive(true);

                return false;

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��簡 �������� ��� ���� ��� ����
            if(dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            // ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
            else
            {
                SetActiveObjects(speaker, false);
                
                return true;
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        // ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
        SetActiveObjects(speaker, false);

        // ���� ��� ����
        currentDialogIndex++;

        // ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        SetActiveObjects(speaker, true);
        // ���� ȭ���� ��� �ؽ�Ʈ ����
        //speaker.textDialog.text = dialogs[currentDialogIndex].dialogs;
        StartCoroutine("OnTypingText");
    }
    
    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.textDialog.gameObject.SetActive(visible);
        speaker.imageDialog.gameObject.SetActive(visible);

        // ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϹǷ� �׻� false
        speaker.objectArrow.SetActive(false);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;

        // �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
        while(index < dialogs[currentDialogIndex].dialogs.Length)
        {
            speaker.textDialog.text = dialogs[currentDialogIndex].dialogs.Substring(0, index);
            
            index++;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
        speaker.objectArrow.SetActive(true);

    }
    // �ý��� ����ȭ 
    [System.Serializable]
    public struct Speaker
    {
        public Image imageDialog; // ��ȭâ Image UI
        public Text textDialog; // ���� ��� ��� Text UI
        public GameObject objectArrow; // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ
    }

    [System.Serializable]
    public struct DialogData
    {
        public int speakerIndex; // �̸��� ��縦 ����� ���� DialogueSystem�� Speaker �迭 ����
        [TextArea(3, 5)]
        public string dialogs; // ���
    }
}
