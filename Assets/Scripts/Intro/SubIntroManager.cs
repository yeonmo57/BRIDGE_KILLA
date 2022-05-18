using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubIntroManager : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    public void Fade()
    {
        
        StartCoroutine(FadeFlow());
        
    }

    IEnumerator FadeFlow()
    {
        yield return new WaitForSeconds(2f);

        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null; 
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Intro4");
    }
}
