using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���⼭ ���ϴ� �������� make�� ��ᰡ �Ǵ� ���� �Դϴ�

//FieldItems ��ũ��Ʈ�� ����
public class MakeController : MonoBehaviour
{
    //��ǳ�� �̹���
    public GameObject log1;
    public GameObject log2;
    public GameObject log3;

    public GameObject EndBlackBox;

    //������ ��Ÿ���� �ؽ�Ʈ
    private Text lily;
    private Text stock; //����ũ��� �� �̸� �Դϴ�(�츮��: �����ɹ�)
    public int numlily;
    public int numstock;

    //�̹���
    //��ǳ����
    public Sprite lily_img;
    public Sprite stock_img;
    public Sprite serve_img; //���� �չٴ� 
    public Sprite play_img; //ȭ��ǥ

    public GameObject Buttonlily;
    public GameObject Buttonstock;

    //Image thisImg; //���� �̹���

    private int numClick=0; //���° ������ ��������

    private void Start()
    {
        lily = GameObject.Find("Material_Name_Lily").GetComponent<Text>();
        stock = GameObject.Find("Material_Name_Stock").GetComponent<Text>();

        //thisImg = GetComponent<Image>();

        numlily = 9;
        numstock = 9;
        lily.text = numlily.ToString() + "��";
        stock.text = numlily.ToString() + "��";
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

        //�̹��� ����
        //�̹��� Ȱ��ȭ

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

    //3�� ������ ���� ��������
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

        log1.SetActive(false);
        log2.SetActive(false);
        log3.SetActive(false);

        EndBlackBox.SetActive(false);
    }

    public void OnclickPlay()
    {
        //���ڽ��� ȭ���� ����
        EndBlackBox.SetActive(true);
        StartCoroutine(EndAnimate());


        //����ī�ֵ���
        //���ڽ� �ϳ��� ����, ����ī�� Ŀ��(?), �ܼ�â�� ����ī�� �̸� ����(�ؽ�Ʈ)

        //����. ��ȭ������ ���ư���
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
