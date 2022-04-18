using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // ���� ����
    public GameObject Potion1; // ������

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
