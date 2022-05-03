using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBtnMove : MonoBehaviour
{
    public GameObject character; //1번 버튼
    public Transform Target; //장소 버튼
    //Vector3 vel = Vector3.zero;

    //1번 버튼이 장소버튼 위치로 이동
    public void OnClickPlace1()
    {
        //Debug.Log("Button Click");
        transform.position = Vector3.MoveTowards(character.transform.position, Target.transform.position, 1f * Time.deltaTime);

    }
}
