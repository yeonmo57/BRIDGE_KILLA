using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker speaker; // 대화에 참여하는 캐릭터의 UI 
    [SerializeField]
    private DialogData[] dialogs; // 현재 분기의 대사 목록 배열
    [SerializeField]
    private bool isAutoStart = true; // 자동 시작 여부
    private bool isFirst = true; // 최초 1회만 호출하기 위한 변수
    private int currentDialogIndex = -1; // 현재 대사 순번
    private float typingSpeed = 0.1f; // 텍스트 타이핑 효과의 재생 속도
    private bool isTypingEffect = false; // 텍스트 타이핑 효과를 재생중인지


    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // 모든 대화 관련 게임 오브젝트 비활성화
        SetActiveObjects(speaker, false);
    }

    public bool UpdateDialog()
    {
        // 대사 분기가 시작될 때 1회만 노출
        if(isFirst == true)
        {   
            // 초기화, 캐릭터 이미지 활성화, 대사 관련 UI 모두 비활성화
            Setup();

            // 자동 재생으로 설정되어 있으면 첫번째 대사 재생
            if (isAutoStart) SetNextDialog();

            isFirst = false;
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 텍스트 타이핑 효과를 재생중일 때 스페이스 누르면 타이핑 효과 종료
            if (isTypingEffect == true)
            {
                isTypingEffect = false;

                // 타이핑 효과를 중지하고, 현재 대사 전체를 출력
                StopCoroutine("OnTypingText");
                speaker.textDialog.text = dialogs[currentDialogIndex].dialogs;

                // 대사가 완료되었을 때 출력되는 커서 활성화
                speaker.objectArrow.SetActive(true);

                return false;

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 대사가 남아있을 경우 다음 대사 진행
            if(dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            // 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고 true 반환
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
        // 이전 화자의 대화 관련 오브젝트 비활성화
        SetActiveObjects(speaker, false);

        // 다음 대사 진행
        currentDialogIndex++;

        // 현재 화자의 대화 관련 오브젝트 활성화
        SetActiveObjects(speaker, true);
        // 현재 화자의 대사 텍스트 설정
        //speaker.textDialog.text = dialogs[currentDialogIndex].dialogs;
        StartCoroutine("OnTypingText");
    }
    
    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.textDialog.gameObject.SetActive(visible);
        speaker.imageDialog.gameObject.SetActive(visible);

        // 화살표는 대사가 종료되었을 때만 활성화하므로 항상 false
        speaker.objectArrow.SetActive(false);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;

        // 텍스트를 한글자씩 타이핑치듯 재생
        while(index < dialogs[currentDialogIndex].dialogs.Length)
        {
            speaker.textDialog.text = dialogs[currentDialogIndex].dialogs.Substring(0, index);
            
            index++;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        // 대사가 완료되었을 때 출력되는 커서 활성화
        speaker.objectArrow.SetActive(true);

    }
    // 시스템 직렬화 
    [System.Serializable]
    public struct Speaker
    {
        public Image imageDialog; // 대화창 Image UI
        public Text textDialog; // 현재 대사 출력 Text UI
        public GameObject objectArrow; // 대사가 완료되었을 때 출력되는 커서 오브젝트
    }

    [System.Serializable]
    public struct DialogData
    {
        public int speakerIndex; // 이름과 대사를 출력할 현재 DialogueSystem의 Speaker 배열 순번
        [TextArea(3, 5)]
        public string dialogs; // 대사
    }
}
