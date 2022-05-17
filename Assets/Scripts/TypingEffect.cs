using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject EndCursor;
    string targetMsg;
    Text msgText;
    int index;

    private void Awake()
    {
        msgText = GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        // 시간차 반복 호출
        Invoke("Effecting",1/CharPerSeconds);
    }

    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", 1 / CharPerSeconds);
    }

    void EffectEnd()
    {
        EndCursor.SetActive(true);
    }
}
