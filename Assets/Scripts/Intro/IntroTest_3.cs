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

    public Image Bag;
    public LevelManager levelManager;
    public Text itemText;

    int textIndex;
    bool isClick;
    string objectName;
    GameObject clickedObject;

    // 페이드인 시간 조절
    float time = 0f;
    float F_time = 5f;

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

        if (levelManager.count == 7)
        {
            StartCoroutine(FadeFlow());
            return; 
        }

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

    IEnumerator FadeFlow()
    {
        yield return new WaitForSeconds(1.5f);

        Bag.gameObject.SetActive(true);
        Color alpha = Bag.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Bag.color = alpha;
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("SubIntro");
    }
}
