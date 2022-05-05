using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    SpriteRenderer sr;
    Vector3 pbl;

    [Header("검은 화면 페이드아웃")]
    public GameObject background;

    [Header("판도라의 상자")]
    public GameObject pandoraBox;
   
    

    // Start is called before the first frame update
    void Start()
    { 
        sr = background.GetComponent<SpriteRenderer>();
        float alphaValue = sr.color.a;
        Debug.Log("현재 투명도는 : "+ alphaValue);
        StartCoroutine(FadeCoroutine(alphaValue));
    }

    IEnumerator FadeCoroutine(float alphaValue) 
    {
        while (alphaValue > 0)
        {
            alphaValue -= 0.005f;
            yield return new WaitForSeconds(0.001f);
            sr.color = new Color(0, 0, 0, alphaValue);
        }

    }

   
 
 
}
