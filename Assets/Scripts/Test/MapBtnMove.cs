using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBtnMove : MonoBehaviour
{
    public GameObject character; //1�� ��ư
    public Transform Target; //��� ��ư
    //Vector3 vel = Vector3.zero;

    //1�� ��ư�� ��ҹ�ư ��ġ�� �̵�
    public void OnClickPlace1()
    {
        //Debug.Log("Button Click");
        transform.position = Vector3.MoveTowards(character.transform.position, Target.transform.position, 1f * Time.deltaTime);

    }
}
