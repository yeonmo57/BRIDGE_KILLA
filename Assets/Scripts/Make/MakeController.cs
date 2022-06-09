using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//여기서 말하는 아이템은 make의 재료가 되는 약초 입니다

//FieldItems 스크립트의 응용
public class MakeController : MonoBehaviour
{
    //말풍선 이미지
    public GameObject log1;
    public GameObject log2;
    public GameObject log3;

    public GameObject EndBlackBox;

    //개수를 나타내는 텍스트
    private Text lily;
    private Text stock; //스토크라는 꽃 이름 입니다(우리말: 비단향꽃무)
    public int numlily;
    public int numstock;

    //이미지
    //말풍선용
    public Sprite lily_img;
    public Sprite stock_img;
    public Sprite serve_img; //제공 손바닥 
    public Sprite play_img; //화살표

    public GameObject Buttonlily;
    public GameObject Buttonstock;

    //Image thisImg; //현재 이미지

    private int numClick=0; //몇번째 아이템 선택인지

    private void Start()
    {
        lily = GameObject.Find("Material_Name_Lily").GetComponent<Text>();
        stock = GameObject.Find("Material_Name_Stock").GetComponent<Text>();

        //thisImg = GetComponent<Image>();

        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "개";
        stock.text = numlily.ToString() + "개";
    }

    void Update()
    {
        

    }

    public void Onclicklily()
    {
        //아이템 수량 변수 감소, 텍스트 반영
        numlily -= 1;
        lily.text = numlily.ToString() + "개";
        
        //몇번째 선택인지 변수 증가
        numClick += 1;

        //이미지 변경
        //이미지 활성화

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
    }

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

    //3번 눌러서 선택 끝났을때
    public void choiceEnd()
    {
        GameObject PlayButton = GameObject.Find("Play_Button");
        //PlayButton.GetComponent<Button>().interactable = false;

        if (numClick == 3)
        {
            Buttonlily.GetComponent<Button>().interactable = false;
            Buttonstock.GetComponent<Button>().interactable = false;

            PlayButton.GetComponent<Image>().sprite = serve_img;
            PlayButton.GetComponent<Button>().interactable = true;

            //GameObject EndBlackBox = GameObject.Find("EndBlackBox");
            
        }
    }

    public void OnclickRetry()
    {
        //전부 초기화
        GameObject PlayButton = GameObject.Find("Play_Button");
        Buttonlily.GetComponent<Button>().interactable = true;
        Buttonstock.GetComponent<Button>().interactable = true;

        PlayButton.GetComponent<Image>().sprite = play_img;
        PlayButton.GetComponent<Button>().interactable = false;

        numClick = 0;
        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "개";
        stock.text = numlily.ToString() + "개";

        log1.SetActive(false);
        log2.SetActive(false);
        log3.SetActive(false);

        EndBlackBox.SetActive(false);
    }

    public void OnclickPlay()
    {
        //블랙박스가 화면을 덮음
        EndBlackBox.SetActive(true);
        StartCoroutine(EndAnimate());


        //마데카솔등장
        //블랙박스 하나더 등장, 마데카솔 커짐(?), 콘솔창에 마데카솔 이름 등장(텍스트)

        //종료. 대화씬으로 돌아가기
    }

    private IEnumerator EndAnimate()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("wait");

        if (numlily == 6)
        {
            StartCoroutine(LilyEnd());
            Debug.Log("num==6");
        }
        else if (numstock == 6)
        {
            StartCoroutine(StockEnd());
            Debug.Log("num==6");
        }
    }

    private IEnumerator LilyEnd()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("lilyend");
    }

    private IEnumerator StockEnd()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("stockend");
    }
}
