using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerMove : MonoBehaviour
{

    //public GameObject cliff; //바위
    //public GameObject field;
    public float speed = 1.0f;

    
    [SerializeField] Transform[] cliffPos; 
    int cliffNum = 0; 

    [SerializeField] Transform[] fieldPos; 
    int fieldNum = 0; 

    bool move = false;
    bool move_field = false;

    //애니메이션
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = cliffPos[cliffNum].transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            Movecliff();
        }

        if (move_field == true)
        {
            Movefield();
        }
    }

    public void OnclickCliff()
    {
        
        Debug.Log("Button Click");
        move = true;
    }

    public void OnclickField()
    {
        animator.SetBool("Right", true);
        Debug.Log("Button Click");
        move_field = true;
        //way = 1;
    }

    public void Movecliff()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, cliffPos[cliffNum].transform.position, speed * Time.deltaTime);

        if (transform.position == cliffPos[cliffNum].transform.position)
        {
            cliffNum++;
        }

        if (cliffNum == cliffPos.Length)
        {
            //해당 씬으로 이동
            move = false;
            Debug.Log("Next Scenes");
        }
    }

    public void Movefield()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, fieldPos[fieldNum].transform.position, speed * Time.deltaTime);

        if (transform.position == fieldPos[fieldNum].transform.position)
        {
            fieldNum++;
        }

        if (fieldNum == fieldPos.Length)
        {
            //해당 씬으로 이동
            animator.SetBool("Right", false);
            move_field = false;
            Debug.Log("Next field Scenes");
        }
    }

}
