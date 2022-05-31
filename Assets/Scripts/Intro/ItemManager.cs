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
        itemData.Add(100, new string[] { "<b>å.</b> ���ݼ��� ���õ� �߿��� �������� �����־�." });
        itemData.Add(101, new string[] { "<b>�Ǹ���.</b> ���� ������ ���� ������ �ʿ��ϰ� �ɰž�." });
        itemData.Add(102, new string[] { "<b>��.</b> �װ������� �� ���� ���� �ٶ���." });
        itemData.Add(103, new string[] { "<b>�����ָӴ�.</b> ���� ���� �� �ʿ��� ������ ����־�." });
        itemData.Add(104, new string[] { "<b>����.</b> �� ������ ������, �׸��� �� ����� �ذ�å." });
        itemData.Add(105, new string[] { "<b>���´��� �Ҵ�Ʈ.</b> ���´�.. �� ã�Ƴ��ڽ��ϴ�, ���´��� ���� �ڸ�." });
        itemData.Add(106, new string[] { "<b>����.</b>. �װ����� �ڰ�, �Ա� ���ؼ��� ���� �ʿ��ϰ���." });

    }

    public string GetText(int id, int textIndex)
    {
        if (textIndex == itemData[id].Length)
            return null;
        else
            return itemData[id][textIndex];
    }
}
