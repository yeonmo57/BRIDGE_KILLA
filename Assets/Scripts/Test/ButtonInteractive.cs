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
        // PotionMaker�� count �� Ȯ��
        if(PotionMaker.count >= 3)
        {
            // Ŭ�� Ƚ���� 3�� �Ѿ�� ��� ��ư ��Ȱ��ȭ
            material1.interactable = false;
            material2.interactable = false;
            material3.interactable = false;
        }
    }
}
