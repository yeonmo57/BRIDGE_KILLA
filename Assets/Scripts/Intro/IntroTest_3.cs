using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTest_3 : MonoBehaviour
{
    public ItemManager itemManager;
    public GameObject DialogImage;
    
    public Text itemText;
    int textIndex;
    bool isClick;
    string objectName;
    GameObject clickedObject;

    void Update()
    {
        // ������Ʈ Ŭ����
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInformation = Physics2D.Raycast(clickPos, Camera.main.transform.forward);
            if(hitInformation.collider != null)
            {
                clickedObject = hitInformation.transform.gameObject;
                objectName = clickedObject.name;


                Click(objectName);

            }
        }

    }

    public void Click(string objectName)
    {
        GameObject obj = GameObject.Find(objectName);
        Debug.Log(obj);
        ObjData objData = obj.GetComponent<ObjData>();
        TextLog(objData.id, objData.isNpc);

        DialogImage.SetActive(isClick);

    }

    void TextLog(int id, bool isNpc)
    {
        string itemData = itemManager.GetText(id, textIndex);

        if(itemData == null)
        {
            isClick = false;
            textIndex = 0; // ��ȭ ���� �� index �ʱ�ȭ
            return; //  ���� ����
        }

        if (isNpc)
        {
            itemText.text = itemData;  
        }
        else
        {
            itemText.text = itemData;
        }

        isClick = true;
        textIndex++;
    }
}
