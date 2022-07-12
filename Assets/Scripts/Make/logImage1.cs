using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class logImage1 : MonoBehaviour
{
    public Sprite lily_img;
    public Sprite stock_img;
    public Sprite none_img;
    Image thisImg;

    // Start is called before the first frame update
    public void Start()
    {
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void Change_lily()
    {
        thisImg.sprite = lily_img;
    }

    public void Change_stock()
    {
        thisImg.sprite = stock_img;
    }

    public void Change_Retry()
    {
        thisImg.sprite = none_img;
    }

}
