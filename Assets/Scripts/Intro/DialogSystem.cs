using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; // ��ȭ�� �����ϴ� ĳ������ UI 
    [SerializeField]
    private DialogData[] dialogs; // ���� �б��� ��� ��� �迭
    [SerializeField]
    private bool isAutoStart = true; // �ڵ� ���� ����
    private bool isFirst = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
    private int currentDialogIndex = -1; // ���� ��� ����
    private int currentSpeakerIndex = 0;

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // ��� ��ȭ ���� ���� ������Ʈ ��Ȱ��ȭ
        for(int i =0; i< speakers.Length; i++)
        {
            SetActiveObjects(speakers[i], false);

            //ĳ���� �̹����� ���̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
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
            // ��簡 �������� ��� ���� ��� ����
            if(dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            // ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
            else
            {
                for(int i = 0;i< speakers.Length; i++)
                {
                    SetActiveObjects(speakers[i], false);
                    // SetActiveObjects()�� ĳ���� �̹����� ������ ���� �ϴ� �κ��� �����Ƿ� ������ ȣ��
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }

                return true;
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        // ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
        SetActiveObjects(speakers[currentDialogIndex], false);

        // ���� ��� ����
        currentDialogIndex++;

        // ���� ȭ�� ���� ����
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        // ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], true);
        // ���� ȭ���� �̸� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
        // ���� ȭ���� ��� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textDialog.text = dialogs[currentDialogIndex].dialogs;
    }
    
    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialog.gameObject.SetActive(visible);

        // ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϹǷ� �׻� false
        speaker.objectArrow.SetActive(false);

        // ĳ���� ���İ� ���� 
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }
    // �ý��� ����ȭ 
    [System.Serializable]
    public struct Speaker
    {
        public SpriteRenderer spriteRenderer; // ĳ���� �̹��� 
        public Image imageDialog; // ��ȭâ Image UI
        public Text textName; // ���� ��� ���� ĳ���� �̸� ��� Text UI
        public Text textDialog; // ���� ��� ��� Text UI
        public GameObject objectArrow; // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ
    }

    [System.Serializable]
    public struct DialogData
    {
        public int speakerIndex; // �̸��� ��縦 ����� ���� DialogueSystem�� Speaker �迭 ����
        public string name; // ĳ���� �̸�
        [TextArea(3, 5)]
        public string dialogs; // ���
    }
}
