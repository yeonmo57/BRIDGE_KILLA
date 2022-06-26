using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//여기서 말하는 아이템은 make의 재료가 되는 약초 입니다

//FieldItems 스크립트의 응용
public class MakeController : MonoBehaviour
{
    public GameObject log1;
    public GameObject log2;
    public GameObject log3;

    public GameObject EndBlackBox;
    public GameObject EndBlackBox2;

    public GameObject Making_IMG1;
    public GameObject Making_IMG2;
    public GameObject Making_IMG3;

    public GameObject madecassol;

    //개수를 나타내는 텍스트
    private Text lily;
    private Text stock; //스토크라는 꽃 이름 입니다(우리말: 비단향꽃무)
    private Text Medecine_Name;
    public int numlily;
    public int numstock;

    //이미지
    //말풍선용
    public Sprite lily_img;
    public Sprite stock_img;
    public Sprite serve_img; //제공 손바닥 
    public Sprite play_img; //화살표
    public Sprite lily_making_img;
    //public Sprite stock_making_img;

    

    public GameObject Buttonlily;
    public GameObject Buttonstock;

    private int numClick=0; //몇번째 아이템 선택인지

    bool serve;//false일때는 아이템 만드는 함수, true가 되면 제공하는 기능

    //!!!여기서부터 신 코드!!!
    public int index_lily = 2;
    public int ans = 1;
    int[] medicine_name = new int[3]{ 8, 27,0 };
    public int temp = 1;

    //public GameObject logImage1;


    private void Start()
    {
        

        lily = GameObject.Find("Material_Name_Lily").GetComponent<Text>();
        //stock = GameObject.Find("Material_Name_Stock").GetComponent<Text>();

        Medecine_Name = GameObject.Find("Make_CompletionName").GetComponent<Text>();

        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "개";
        //stock.text = numlily.ToString() + "개";

        serve = false;
    }

    void Update()
    {
        

    }

    public void Onclicklily()
    {
        GameObject.Find("InMaterial_LogImage1").GetComponent<logImage1>().ChangeImage1();
        /*
        //아이템 수량 변수 감소, 텍스트 반영
        numlily -= 1;
        lily.text = numlily.ToString() + "개";
        
        //몇번째 선택인지 변수 증가
        numClick++;

        if (numClick == 1)
        {
            log1.GetComponent<Image>().sprite = lily_img;
            log1.SetActive(true);
        }
        
        else if (numClick == 2)
        {
            log2.GetComponent<Image>().sprite = lily_img;
            log2.SetActive(true);
        }
        else if (numClick == 3)
        {
            log3.GetComponent<Image>().sprite = lily_img;
            log3.SetActive(true);
        }
        //만약 세번째 클릭이면 제공으로 이미지 버튼 변경
        choiceEnd();
        */

        //!!!여기서부터 신 코드!!!
        temp *= index_lily;
        
    }

    public void click_1st()
    {

    }

    public void click_2nd()
    {

    }

    public void click_3rd()
    {

    }


    /*
    public void Onclickstock()
    {
        numstock -= 1;
        stock.text = numstock.ToString() + "개";
        numClick += 1;

        if (numClick == 1)
        {
            log1.GetComponent<Image>().sprite = stock_img;
            log1.SetActive(true);
        }
        else if (numClick == 2)
        {
            log2.GetComponent<Image>().sprite = stock_img;
            log2.SetActive(true);
        }
        else if (numClick == 3)
        {
            log3.GetComponent<Image>().sprite = stock_img;
            log3.SetActive(true);
        }
        choiceEnd();
    }
    */

    //3번 눌러서 선택 끝났을때
    public void choiceEnd()
    {
        GameObject PlayButton = GameObject.Find("Play_Button");

        if (numClick == 3)
        {
            Buttonlily.GetComponent<Button>().interactable = false;
            //Buttonstock.GetComponent<Button>().interactable = false;
            
            PlayButton.GetComponent<Button>().interactable = true;    
        }
    }

    public void OnclickRetry()
    {
        //전부 초기화
        GameObject PlayButton = GameObject.Find("Play_Button");
        Buttonlily.GetComponent<Button>().interactable = true;
        //Buttonstock.GetComponent<Button>().interactable = true;

        PlayButton.GetComponent<Image>().sprite = play_img;
        PlayButton.GetComponent<Button>().interactable = false;

        numClick = 0;
        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "개";
        //stock.text = numlily.ToString() + "개";

        log1.SetActive(false);
        log2.SetActive(false);
        log3.SetActive(false);

        EndBlackBox.SetActive(false);
    }

    public void OnclickPlay()
    {
        //false일때는 아이템 만드는 함수, true가 되면 제공하는 기능
        if (serve == false)
        {
            GameObject PlayButton = GameObject.Find("Play_Button");
            PlayButton.GetComponent<Button>().interactable = false;

            EndBlackBox.SetActive(true);
            StartCoroutine(EndAnimate());
            serve = true;
        }
        else if(serve == true)
        {
            //제공하는 씬 호출
            SceneManager.LoadScene("Day1-2");
        }
    }

    private IEnumerator EndAnimate()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("wait");

        if (numlily == 6)
        {
            StartCoroutine(LilyEnd());
            Debug.Log("lilynum==6");
        }
        else if (numstock == 6)
        {
            StartCoroutine(StockEnd());
            Debug.Log("stocknum==6");
        }
    }

    private IEnumerator LilyEnd()
    {
        Making_IMG1.GetComponent<Image>().sprite = lily_making_img;
        Making_IMG2.GetComponent<Image>().sprite = lily_making_img;
        Making_IMG3.GetComponent<Image>().sprite = lily_making_img;

        yield return new WaitForSeconds(1f);
        Making_IMG1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Making_IMG2.SetActive(true);
        yield return new WaitForSeconds(1f);
        Making_IMG3.SetActive(true);

        yield return new WaitForSeconds(2f);
        Making_IMG1.SetActive(false);
        Making_IMG2.SetActive(false);
        Making_IMG3.SetActive(false);

        EndBlackBox2.SetActive(true);

        GameObject PlayButton = GameObject.Find("Play_Button");
        PlayButton.GetComponent<Image>().sprite = serve_img;
        PlayButton.GetComponent<Button>().interactable = true;
        Medecine_Name.text = "~마데카솔~";
        madecassol.SetActive(true);
        Debug.Log("lilyend");
    }

    private IEnumerator StockEnd()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("stockend");
    }


    //!!!여기서부터 신 코드!!!
    public void calculate()
    {
        if (numClick == 3)
        {
            //for문 돌려서 list 속에서 해당하는 값 찾기
            for (int i = 0; i < medicine_name.Length; i++)
            {
                if (medicine_name[i] == temp)
                {
                    ans = i; 
                }
            }

        }
    }

}

