using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    
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

