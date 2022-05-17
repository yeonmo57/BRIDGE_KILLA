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
        itemData.Add(100, new string[] { "책이다.", "여행갈 때 없으면 망한다." });
    }

    public string GetText(int id, int textIndex)
    {
        if (textIndex == itemData[id].Length)
            return null;
        else
            return itemData[id][textIndex];
    }
}
