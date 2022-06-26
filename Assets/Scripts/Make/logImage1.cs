using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class logImage1 : MonoBehaviour
{
    public Sprite stock_img;
    Image thisImg1;

    // Start is called before the first frame update
    public void Start()
    {
        thisImg1 = GetComponent<Image>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void ChangeImage1()
    {
        thisImg1.sprite = stock_img;
    }
}
