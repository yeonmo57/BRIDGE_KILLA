using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���⼭ ���ϴ� �������� make�� ��ᰡ �Ǵ� ���� �Դϴ�

//FieldItems ��ũ��Ʈ�� ����
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
    //public Sprite stock_making_img;

    public GameObject Buttonlily;
    public GameObject Buttonstock;

    private int numClick=0; //���° ������ ��������

    bool serve;//false�϶��� ������ ����� �Լ�, true�� �Ǹ� �����ϴ� ���


    private void Start()
    {
        lily = GameObject.Find("Material_Name_Lily").GetComponent<Text>();
        //stock = GameObject.Find("Material_Name_Stock").GetComponent<Text>();

        Medecine_Name = GameObject.Find("Make_CompletionName").GetComponent<Text>();

        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "��";
        //stock.text = numlily.ToString() + "��";

        serve = false;
    }

    void Update()
    {
        

    }

    public void Onclicklily()
    {
        //������ ���� ���� ����, �ؽ�Ʈ �ݿ�
        numlily -= 1;
        lily.text = numlily.ToString() + "��";
        
        //���° �������� ���� ����
        numClick += 1;

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
        //���� ����° Ŭ���̸� �������� �̹��� ��ư ����
        choiceEnd();
    }

    /*
    public void Onclickstock()
    {
        numstock -= 1;
        stock.text = numstock.ToString() + "��";
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

    //3�� ������ ���� ��������
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
        //���� �ʱ�ȭ
        GameObject PlayButton = GameObject.Find("Play_Button");
        Buttonlily.GetComponent<Button>().interactable = true;
        //Buttonstock.GetComponent<Button>().interactable = true;

        PlayButton.GetComponent<Image>().sprite = play_img;
        PlayButton.GetComponent<Button>().interactable = false;

        numClick = 0;
        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "��";
        //stock.text = numlily.ToString() + "��";

        log1.SetActive(false);
        log2.SetActive(false);
        log3.SetActive(false);

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
            Debug.Log("serve");
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
        Medecine_Name.text = "~����ī��~";
        madecassol.SetActive(true);
        Debug.Log("lilyend");
    }

    private IEnumerator StockEnd()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("stockend");
    }
}