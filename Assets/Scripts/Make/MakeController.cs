using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//���⼭ ���ϴ� �������� make�� ��ᰡ �Ǵ� ���� �Դϴ�

//FieldItems ��ũ��Ʈ�� ����
public class MakeController : MonoBehaviour
{
    public GameObject EndBlackBox;
    public GameObject EndBlackBox2;

    public GameObject Making_IMG1;
    public GameObject Making_IMG2;
    public GameObject Making_IMG3;

    public GameObject madecassol;

    //������ ��Ÿ���� �ؽ�Ʈ
    private Text lily;
    private Text stock; //����ũ��� �� �̸� �Դϴ�(�츮��: �����ɹ�)
    private Text Medecine_Name;
    public int numlily;
    public int numstock;

    //�̹���
    //��ǳ����
    public Sprite lily_img;
    public Sprite stock_img;
    public Sprite serve_img; //���� �չٴ� 
    public Sprite play_img; //ȭ��ǥ
    public Sprite lily_making_img;
    public Sprite stock_making_img;

    public GameObject Buttonlily;
    public GameObject Buttonstock;

    private int numClick=0; //���° ������ ��������

    bool serve;//false�϶��� ������ ����� �Լ�, true�� �Ǹ� �����ϴ� ���

    //!!!���⼭���� ������ ��!!!
    public int index_lily = 2;
    public int index_stock = 3;
    public int temp = 1;
    //���� �ʿ������?
    public int ans = 1;
    int[] medicine_name = new int[3]{ 8, 27,0 }; 

    //public GameObject logImage1;

    private void Start()
    {
        lily = GameObject.Find("Material_Name_Lily").GetComponent<Text>();
        stock = GameObject.Find("Material_Name_Stock").GetComponent<Text>();

        Medecine_Name = GameObject.Find("Make_CompletionName").GetComponent<Text>();

        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "��";
        stock.text = numlily.ToString() + "��";

        serve = false;
    }

    void Update()
    {
        

    }

    public void Onclicklily()
    {
        //���° �������� ���� ����
        numClick++;
        //������ ���� ���� ����, �ؽ�Ʈ �ݿ�
        numlily -= 1;
        lily.text = numlily.ToString() + "��";

        if (numClick == 1)
        {
            GameObject.Find("InMaterial_LogImage1").GetComponent<logImage1>().Change_lily();
        }
        else if (numClick == 2)
        {
            GameObject.Find("InMaterial_LogImage2").GetComponent<logImage1>().Change_lily();
        }
        else if (numClick == 3)
        {
            GameObject.Find("InMaterial_LogImage3").GetComponent<logImage1>().Change_lily();
            choiceEnd();
        }

        //!!!���⼭���� �� �ڵ�!!!
        temp *= index_lily;
    }

    public void Onclickstock()
    {
        numClick++;
        numstock -= 1;
        stock.text = numstock.ToString() + "��";

        if (numClick == 1)
        {
            GameObject.Find("InMaterial_LogImage1").GetComponent<logImage1>().Change_stock();
        }
        else if (numClick == 2)
        {
            GameObject.Find("InMaterial_LogImage2").GetComponent<logImage1>().Change_stock();
        }
        else if (numClick == 3)
        {
            GameObject.Find("InMaterial_LogImage3").GetComponent<logImage1>().Change_stock();
            choiceEnd();
        }
        temp *= index_stock;
    }
    
    //3�� ������ ���� ��������
    public void choiceEnd()
    {
        GameObject PlayButton = GameObject.Find("Play_Button");

        //������ �κ�: ��ư�� ���ڷ� �±��ؼ� �ݺ��� ������
        Buttonlily.GetComponent<Button>().interactable = false;
        Buttonstock.GetComponent<Button>().interactable = false;
            
        PlayButton.GetComponent<Button>().interactable = true;     
    }

    public void OnclickRetry()
    {
        //���� �ʱ�ȭ
        GameObject PlayButton = GameObject.Find("Play_Button");
        Buttonlily.GetComponent<Button>().interactable = true;
        Buttonstock.GetComponent<Button>().interactable = true;

        PlayButton.GetComponent<Image>().sprite = play_img;
        PlayButton.GetComponent<Button>().interactable = false;

        numClick = 0;
        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "��";
        stock.text = numlily.ToString() + "��";

        GameObject.Find("InMaterial_LogImage1").GetComponent<logImage1>().Change_Retry();
        GameObject.Find("InMaterial_LogImage2").GetComponent<logImage1>().Change_Retry();
        GameObject.Find("InMaterial_LogImage3").GetComponent<logImage1>().Change_Retry();

        EndBlackBox.SetActive(false);
    }

    public void OnclickPlay()
    {
        //false�϶��� ������ ����� �Լ�, true�� �Ǹ� �����ϴ� ���
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
            //�����ϴ� �� ȣ��
            SceneManager.LoadScene("Day1-2");
        }
    }

    //� �������� �Ǵ�
    private IEnumerator EndAnimate()
    {
        yield return new WaitForSeconds(1f);
        //calculate();
        if (temp == 8)
        {
            StartCoroutine(LilyEnd());       
        }
        else if (temp == 27)
        {
            StartCoroutine(StockEnd());
        }
        temp = 1;
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
        Medecine_Name.text = "~����ī��~";
        madecassol.SetActive(true);
        Debug.Log("lilyend");
    }

    private IEnumerator StockEnd()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("stockend");
    }


   
    /*
    public void calculate()
    {
        if (numClick == 3)
        {
            //for�� ������ list �ӿ��� �ش��ϴ� �� ã��
            for (int i = 0; i < medicine_name.Length; i++)
            {
                if (medicine_name[i] == temp)
                {
                    ans = i; 
                }
            }

        }
    }
    */
}