using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public Camera cam;
    public Animation animation;
    public GameObject player;
    
    Vector3 inputPos;
    Vector2 dir;
    bool move;

    // Start is called before the first frame update
    void Start()
    {


        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (Input.GetMouseButtonDown(0))
                inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            dir = inputPos - player.transform.position;

            //if(dir!= Vector2.zero)

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
        


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Portal_L")
        {
            if (collision.transform.name == "Portal_L")
            {
                Debug.Log("충돌감지, 왼쪽 이동");
                animation.Play("Left");
                move = false;
                player.transform.position = new Vector3(-13f, 0, 0);
            }

            if (collision.transform.name == "Portal_L_2")
            {
                Debug.Log("충돌감지, 오른쪽 이동");
                animation.Play("Left_2");
                move = false;
                player.transform.position = new Vector3(7.9f, 0, 0);
            }            
        }

        if (collision.tag == "Portal_R")
        {
            if (collision.transform.name == "Portal_R_2")
            {
                Debug.Log("충돌감지, 오른쪽 이동");
                animation.Play("Right_2");
                move = false;
                player.transform.position = new Vector3(-7.57f, 0, 0);
            }

            if (collision.transform.name == "Portal_R")
            {
                Debug.Log("충돌감지, 오른쪽 이동");
                animation.Play("Right");
                move = false;
                player.transform.position = new Vector3(12.3f, 0, 0);
            }

        }

        if (collision.tag == "Portal_U")
        {
            if (collision.transform.name == "Portal_U_2") // 아래에서 중앙
            {
                Debug.Log("충돌감지, 위쪽 이동");
                animation.Play("Up_2");
                move = false;
                player.transform.position = new Vector3(0, -3.18f, 0);
            }

            if (collision.transform.name == "Portal_U") // 중앙에서 위
            {
                Debug.Log("충돌감지, 위쪽 이동");
                animation.Play("Up");
                move = false;
                player.transform.position = new Vector3(0, 8.15f, 0);
            }

        }

        if (collision.tag == "Portal_D")
        {
            if (collision.transform.name == "Portal_D")
            {
                Debug.Log("충돌감지, 아래쪽 이동");
                animation.Play("Down");
                move = false;
                player.transform.position = new Vector3(0, -8.2f, 0);
            }

            if (collision.transform.name == "Portal_D_2")
            {
                Debug.Log("충돌감지, 아래쪽 이동");
                animation.Play("Down_2");
                move = false;   
                player.transform.position = new Vector3(0, 3.2f, 0);
            }
        }
    }
}