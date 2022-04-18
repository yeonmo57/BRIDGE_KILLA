using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    int count = 0;

    public GameObject Log1;
    public GameObject Log2;

    void Start()
    {
        Log1.SetActive(false);
        Log2.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Log1.SetActive(true);
            count += 1;
            Debug.Log(count);   
        }

        if(Input.GetMouseButtonDown(0) && count == 1)
        {
            Log2.SetActive(true);
        }

        if(count >= 2)
        {
            Invoke("SceneChange", 2f);
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Workroom_Potion");
    }
}
