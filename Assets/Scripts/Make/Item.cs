using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string itemName;
    public Sprite itemImage;

    //������ ��� ���� ���� ��ȯ
    public bool Use()
    {
        return false;
    }
}
