using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTest_4 : MonoBehaviour
{
    public float cameraSpeed;
    public Camera cam;

    public GameObject canvas;
    public Image gameStart;
    public Image gameLoad;
    public Image Panel;
    
    public Button GameStartButton;

    Vector3 targetPosition;
    
    // 페이드인 시간 조절
    float time = 0f;
    float F_time = 5f;

    void Start()
    {
        GameStartButton.onClick.AddListener(GameStart);
        targetPosition = new Vector3(0, 0, -10);
        StartCoroutine(FadeFlow());
    }


    void Update()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, cameraSpeed * Time.deltaTime);

        StartCoroutine(B_Visible());
    }

    IEnumerator B_Visible()
    {
        yield return new WaitForSeconds(5.7f);
        gameStart.gameObject.SetActive(true);
        gameLoad.gameObject.SetActive(true);

        Color alphaS = gameStart.color;
        Color alphaL = gameLoad.color;

        while (alphaS.a < 1 && alphaL.a < 1)
        {
            time += Time.deltaTime / F_time;
            alphaS.a = Mathf.Lerp(0, 3, time);
            alphaL.a = Mathf.Lerp(0, 3, time);
            gameStart.color = alphaS;
            gameLoad.color = alphaL;
            yield return null;
        }        
    }

    IEnumerator FadeFlow()
    {
        Color alpha = Panel.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / 2;
            alpha.a = Mathf.Lerp(0.9f, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        Panel.gameObject.SetActive(false);
        yield return null;
    }

    void GameStart()
    {
        SceneManager.LoadScene("Day1-1");
    }
}
