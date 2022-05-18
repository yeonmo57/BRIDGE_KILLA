using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject book, gun, poison, wallet, cylinder, medicine, pendant;
    public GameObject bookBlack, gunBlack, poisonBlack, walletBlack, cylinderBlack, medicineBlack, pendantBlack;

    Vector2 bookInitialPos, gunInitialPos, poisonInitialPos, walletInitialPos, cylinderInitialPos, medicineInitialPos, pendantInitialPos;

    // 드롭했을 때 아이템 설명 SetActive = false; 
    public bool arrive;

    // 총 몇개의 아이템이 상자에 담겼는지 count
    public int count; 

    // 각 오브젝트의 초기 위치 설정 
    void Start()
    {
        arrive = false;
        count = 0;
        bookInitialPos = book.transform.position;
        gunInitialPos = gun.transform.position;
        poisonInitialPos = poison.transform.position;
        walletInitialPos = wallet.transform.position;
        cylinderInitialPos = cylinder.transform.position;
        medicineInitialPos = medicine.transform.position;
        pendantInitialPos = pendant.transform.position;

    }


    // 오브젝트 드래그
    public void DragBook()
    {
        book.transform.position = Input.mousePosition;
        arrive = true;
    }

    public void DragGun()
    {
        gun.transform.position = Input.mousePosition;
        arrive = true;
    }

    public void DragPoison()
    {
        poison.transform.position = Input.mousePosition;
        arrive = true;
    }

    public void DragWallet()
    {
        wallet.transform.position = Input.mousePosition;
        arrive = true;
    }

    public void DragCylinder()
    {
        cylinder.transform.position = Input.mousePosition;
        arrive = true;
    }

    public void DragMedicine()
    {
        medicine.transform.position = Input.mousePosition;
        arrive = true;
    }

    public void DragPendant()
    {
        pendant.transform.position = Input.mousePosition;
        arrive = true;
    }

    // 오브젝트 드롭
    public void DropBook()
    {
        float distance = Vector3.Distance(book.transform.position, bookBlack.transform.position);

        if(distance < 50)
        {
            book.transform.position = bookBlack.transform.position;
            book.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            count++;
        }
        else
        {
            book.transform.position = bookInitialPos;
        }

    }

    public void DropGun()
    {
        float distance = Vector3.Distance(gun.transform.position, gunBlack.transform.position);

        if (distance < 50)
        {
            gun.transform.position = gunBlack.transform.position;
            gun.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            count++;
        }
        else
        {
            gun.transform.position = gunInitialPos;
        }

    }

    public void DropWallet()
    {
        float distance = Vector3.Distance(wallet.transform.position, walletBlack.transform.position);

        if (distance < 50)
        {
            wallet.transform.position = walletBlack.transform.position;
            wallet.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            count++;
        }
        else
        {
            wallet.transform.position = walletInitialPos;
        }

    }

    public void DropPoison()
    {
        float distance = Vector3.Distance(poison.transform.position, poisonBlack.transform.position);

        if (distance < 50)
        {
            poison.transform.position = poisonBlack.transform.position;
            poison.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            count++;
        }
        else
        {
            poison.transform.position = poisonInitialPos;
        }

    }

    public void DropCylinder()
    {
        float distance = Vector3.Distance(cylinder.transform.position, cylinderBlack.transform.position);

        if (distance < 50)
        {
            cylinder.transform.position = cylinderBlack.transform.position;
            cylinder.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            count++;
        }
        else
        {
            cylinder.transform.position = cylinderInitialPos;
        }

    }

    public void DropMedicine()
    {
        float distance = Vector3.Distance(medicine.transform.position, medicineBlack.transform.position);

        if (distance < 50)
        {
            medicine.transform.position = medicineBlack.transform.position;
            medicine.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            count++;
        }
        else
        {
            medicine.transform.position = medicineInitialPos;
        }

    }

    public void DropPendant()
    {
        float distance = Vector3.Distance(pendant.transform.position, pendantBlack.transform.position);

        if (distance < 50)
        {
            pendant.transform.position = pendantBlack.transform.position;
            pendant.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            count++;
        }
        else
        {
            pendant.transform.position = pendantInitialPos;
        }

    }
}
