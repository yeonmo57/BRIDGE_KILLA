using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string itemName;
    public Sprite itemImage;

    //아이템 사용 성공 여부 반환
    public bool Use()
    {
        return false;
    }
}
