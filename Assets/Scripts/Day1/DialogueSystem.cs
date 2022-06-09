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

