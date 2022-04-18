using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractive : MonoBehaviour
{
    public Button material1;
    public Button material2;
    public Button material3; 

    

    // Update is called once per frame
    void Update()
    {
        // PotionMaker의 count 값 확인
        if(PotionMaker.count >= 3)
        {
            // 클릭 횟수가 3이 넘어가면 모든 버튼 비활성화
            material1.interactable = false;
            material2.interactable = false;
            material3.interactable = false;
        }
    }
}
