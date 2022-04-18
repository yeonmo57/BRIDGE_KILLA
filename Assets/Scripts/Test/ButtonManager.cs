using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // 약의 종류
    public GameObject Potion1; // 진통제

    public void PotionSetActive()
    {
        Potion1.SetActive(true);
        Invoke("CanvasSetActive", 2f);
    }


    // Canvas Set Active
    public GameObject Canvas_Choice;

    void CanvasSetActive()
    {
        Canvas_Choice.SetActive(true);
    }
}
