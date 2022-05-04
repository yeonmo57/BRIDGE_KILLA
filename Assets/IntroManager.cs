using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    SpriteRenderer sr;

    [Header("���� ȭ�� ���̵�ƿ�")]
    public GameObject background;

    [Header("�ǵ����� ����")]
    public GameObject PandoraBox;

    // Start is called before the first frame update
    void Start()
    {
        sr = background.GetComponent<SpriteRenderer>();
        float alphaValue = sr.color.a;
        Debug.Log("���� ������ : "+ alphaValue);
        StartCoroutine(FadeCoroutine(alphaValue));
    }

    IEnumerator FadeCoroutine(float alphaValue) 
    {
         while (alphaValue > 0)
         {
            Debug.Log("������� �� .. ");
            alphaValue -= 0.01f;
            yield return new WaitForSeconds(0.001f);
            sr.color = new Color(0, 0, 0, alphaValue);
         }
    }

    void PushBox()
    {

    }

    
}
