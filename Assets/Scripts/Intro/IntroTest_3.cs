using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTest_3 : MonoBehaviour
{
    public ItemManager itemManager;
    public GameObject DialogImage;
    public GameObject ArrowImage;

    public LevelManager levelManager;
    public Text itemText;

    int textIndex;
    bool isClick;
    string objectName;
    GameObject clickedObject;
    
    void Update()
    {
        /*
        // 오브젝트 클릭시
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
        */

    }
    
    public void Click()
    {
        // collider만 rayhit 할 수 있게 코드 수정 필요함 

        Vector2 clickPos = Input.mousePosition;
        RaycastHit2D hitInformation = Physics2D.Raycast(clickPos, Camera.main.transform.forward);

        if (hitInformation.collider != null)
        {
            if (hitInformation.collider.gameObject.tag.Equals("Item"))
            {
                clickedObject = hitInformation.transform.gameObject;
                objectName = clickedObject.name;

                GameObject obj = GameObject.Find(objectName);
                ObjData objData = obj.GetComponent<ObjData>();

                TextLog(objData.id, objData.isNpc);
            }

        }

        if (!levelManager.arrive)
        {
            DialogImage.SetActive(isClick);
            ArrowImage.SetActive(isClick);
        }

        levelManager.arrive = false;
    }

    void TextLog(int id, bool isNpc)
    {

        string itemData = itemManager.GetText(id, textIndex);

        if (itemData == null)
        {
            isClick = false;
            textIndex = 0; // 대화 끝날 때 index 초기화
            return; //  강제 종료
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
