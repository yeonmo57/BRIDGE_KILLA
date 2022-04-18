using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;
    public GameObject settingCanvas;

    void Start()
    {
        IsPaused = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        settingCanvas.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        return;
    }

    public void Pause()
    {
        settingCanvas.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        return;
    }

}
