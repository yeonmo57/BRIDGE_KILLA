using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Conversation3Click : MonoBehaviour
{
    int count = 0;

    public GameObject npcLogTest1;
    public GameObject playerTest1;

    // Start is called before the first frame update
    void Start()
    {
        npcLogTest1.SetActive(false);
        playerTest1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            npcLogTest1.SetActive(true);
            count += 1;
            Debug.Log(count);
        }

        if (Input.GetMouseButtonDown(0) && count == 1)
        {
            playerTest1.SetActive(true);
        }

    }
}
