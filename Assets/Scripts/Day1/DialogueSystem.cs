using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; // 대화에 참여하는 캐릭터들의 UI 배열
    [SerializeField]
    private DialogueData[] dialogues; // 현재 분기의 대사 목록 배열
    [SerializeField] 
    private bool isAutoStart = true; // 자동 시작 여부
    private bool isFirst = true; // 최초 1회만 호출하기 위한 변수
    private int currentDialogueIndex = -1; // 현재 대사 순번
    private int currentSpeakerIndex = 0; // 현재 말을 하는 화자의 speakers 배열 순번 
    private float typingSpeed = 0.1f; // 타이핑 효과 재생 속도
    private bool isTypingEffect = false; // 텍스트 타이핑 효과 재생중인지

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // 모든 대화 관련 게임 오브젝트 비활성화 
        for(int i =0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            // 캐릭터 이미지는 보이도록 설정
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialogue()
    {
        // 대사 분기가 시작될 때 1회만 호출
        if (isFirst)
        {
            // 초기화, 캐릭터 이미지는 활성화, 대사 관련 UI 모두 비활성화
            Setup();
            if (isAutoStart) SetNextDialogue();

            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isTypingEffect)
            {
                isTypingEffect = false;
                // 타이핑 효과 중지, 현재 대사 전체 출력
                StopCoroutine("OnTypingEffect");
                speakers[currentSpeakerIndex].textDialogue.text = dialogues[currentDialogueIndex].dialogue;
                // 대사가 완료되었을 때 출력되는 커서 활성화
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;

            }
            // 대사가 남아있을 경우 다음 대사 진행
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
        // 이전 화자의 대화 관련 오브젝트 비활성화
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        // 다음 대사를 진행
        currentDialogueIndex++;

        // 현재 화자 순번 설정
        currentSpeakerIndex = dialogues[currentDialogueIndex].speakerIndex;

        // 현재 화자의 대화 관련 오브젝트 활성화
        SetActiveObjects(speakers[currentSpeakerIndex], true);

        // 현재 화자 이름 텍스트 설정
        speakers[currentSpeakerIndex].textName.text = dialogues[currentDialogueIndex].name;

        // 현재 화자의 대사 텍스트 설정
        speakers[currentSpeakerIndex].textDialogue.text = dialogues[currentDialogueIndex].dialogue;

        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageBox.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

        // 화살표는 대사가 종료되었을 때만 활성화하기 때문에 항상 false
        speaker.objectArrow.gameObject.SetActive(false);

        // 캐릭터 알파값 변경
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
    public SpriteRenderer spriteRenderer; // 캐릭터 이미지
    public Image imageBox; // 대화창 이미지
    public Text textName; // 현재 대사중인 캐릭터 이름 출력
    public Text textDialogue; // 현재 대사 출력
    public GameObject objectArrow; // 커서 오브젝트 
}

[System.Serializable]
public struct DialogueData
{
    public int speakerIndex; // 이름과 대사를 출력할 현재 speaker의 배열 순번
    public string name; // 캐릭터 이름
    [TextArea(3, 5)]
    public string dialogue; // 대사
}

