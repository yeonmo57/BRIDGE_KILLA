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

    /*
    //�̰� ���߿� ���־��մϴ�..�̤� �̷��� �ϰ� ���� �ʾҴµ�..
    public GameObject log1_stock;
    public GameObject log2_stock;
    public GameObject log3_stock;
    */

    //������ ��Ÿ���� �ؽ�Ʈ
    private Text lily;
    private Text stock; //����ũ��� �� �̸� �Դϴ�(�츮��: �����ɹ�)
    private int numlily = 9;
    private int numstock = 9;

    //�̹���
    //��ǳ����
    public Sprite lily_img;
    public Sprite stock_img;
    public Sprite serve_img; //���� �չٴ� 


    public GameObject Buttonlily;
    public GameObject Buttonstock;

    //Image thisImg; //���� �̹���

    private int numClick=0; //���° ������ ��������

    

    private void Start()
    {
        lily = GameObject.Find("Material_Name_Lily").GetComponent<Text>();
        stock = GameObject.Find("Material_Name_Stock").GetComponent<Text>();

        //thisImg = GetComponent<Image>();

        
        
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

    public void OnclickPlay()
    {
        

        //���ڽ��� ȭ���� ����
        //����ī�ֵ���
        //���ڽ� �ϳ��� ����, ����ī�� Ŀ��(?), �ܼ�â�� ����ī�� �̸� ����(�ؽ�Ʈ)

        //����. ��ȭ������ ���ư���
    }

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

        }
    }

}
