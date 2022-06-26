using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Camera cam;
    public GameObject player;

    Animation camAni;
    Animator animator;
    Vector3 inputPos;
    Vector2 dir;
    Rigidbody2D rigid2D;
    bool move;
    float dis;


    // Start is called before the first frame update
    void Start()
    {
        camAni = cam.GetComponent<Animation>();
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        move = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 

        if (move)
        {
            if (Input.GetMouseButtonDown(0))
                inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            dis = player.transform.position.x - inputPos.x;
            dir = inputPos - player.transform.position;


            //if(dir!= Vector2.zero)
            //rigid2D.MovePosition(player.transform.position + inputPos * Time.deltaTime * moveSpeed);
            player.transform.position =
              Vector2.MoveTowards(player.transform.position, inputPos, Time.deltaTime * moveSpeed);

            
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                move = true;
                inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        // animation
        // dis = 현재 캐릭터 x좌표 - 마우스 인풋 x좌표
        // dis > 0일 경우는 인풋이 캐릭터보다 왼쪽 -> left
        // dis < 0일 경우는 인풋이 캐릭터보다 오른쪽 -> right
        animator.SetFloat("hAxis", dis);

        if (dis == 0)
            animator.SetBool("Stay",true);
        else
            animator.SetBool("Stay", false);

    }

    // 카메라 이동
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Portal_L")
        {
            if (collision.transform.name == "Portal_L")
            {
                Debug.Log("충돌감지, 왼쪽 이동");
                camAni.Play("Left");
                move = false;
                player.transform.position = new Vector3(-12.37f, 0, 0); // 수정 완료
            }

            if (collision.transform.name == "Portal_L_2")
            {
                Debug.Log("충돌감지, 오른쪽 이동");
                camAni.Play("Left_2");
                move = false;
                player.transform.position = new Vector3(7f, 0, 0); // 수정 완료
            }            
        }

        if (collision.tag == "Portal_R")
        {
            if (collision.transform.name == "Portal_R_2")
            {
                Debug.Log("충돌감지, 오른쪽 이동");
                camAni.Play("Right_2");
                move = false;
                player.transform.position = new Vector3(-7.12f, 0, 0); // 수정 완료
            }

            if (collision.transform.name == "Portal_R")
            {
                Debug.Log("충돌감지, 오른쪽 이동");
                camAni.Play("Right");
                move = false;
                player.transform.position = new Vector3(12.3f, 0, 0); // 수정 완료
            }

        }

        if (collision.tag == "Portal_U")
        {
            if (collision.transform.name == "Portal_U_2") // 아래에서 중앙
            {
                Debug.Log("충돌감지, 위쪽 이동");
                camAni.Play("Up_2");
                move = false;
                player.transform.position = new Vector3(0, -2.65f, 0); // 수정 완료
            }

            if (collision.transform.name == "Portal_U") // 중앙에서 위
            {
                Debug.Log("충돌감지, 위쪽 이동");
                camAni.Play("Up");
                move = false;
                player.transform.position = new Vector3(0, 8.6f, 0); // 수정 완료
            }

        }

        if (collision.tag == "Portal_D")
        {
            if (collision.transform.name == "Portal_D")
            {
                Debug.Log("충돌감지, 아래쪽 이동");
                camAni.Play("Down");
                move = false;
                player.transform.position = new Vector3(0, -8.7f, 0); // 수정 완료
            }

            if (collision.transform.name == "Portal_D_2")
            {
                Debug.Log("충돌감지, 아래쪽 이동");
                camAni.Play("Down_2");
                move = false;   
                player.transform.position = new Vector3(0, 2.8f, 0); // 수정 완료
            }
        }
    }
}