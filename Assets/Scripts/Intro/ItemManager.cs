using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    Dictionary<int, string[]> itemData;

    private void Awake()
    {
        itemData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        itemData.Add(100, new string[] { "<b>책.</b> 연금술과 관련된 중요한 정보들이 적혀있어." });
        itemData.Add(101, new string[] { "<b>실린더.</b> 약을 제조할 일이 있으면 필요하게 될거야." });
        itemData.Add(102, new string[] { "<b>총.</b> 그곳에서는 쓸 일이 없길 바란다." });
        itemData.Add(103, new string[] { "<b>약초주머니.</b> 약을 만들 때 필요한 재료들이 들어있어." });
        itemData.Add(104, new string[] { "<b>독약.</b> 내 여정의 동반자, 그리고 이 사건의 해결책." });
        itemData.Add(105, new string[] { "<b>스승님의 팬던트.</b> 스승님.. 꼭 찾아내겠습니다, 스승님을 죽인 자를." });
        itemData.Add(106, new string[] { "<b>지갑.</b>. 그곳에서 자고, 먹기 위해서는 돈이 필요하겠지." });

    }

    public string GetText(int id, int textIndex)
    {
        if (textIndex == itemData[id].Length)
            return null;
        else
            return itemData[id][textIndex];
    }
}
