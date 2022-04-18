using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoideMaker : MonoBehaviour
{
    //재료 생성
    //3번째 하늘색 병
    public GameObject spoidebottle3;
    public GameObject buttonmake;

    public static int count = 0;

    public void spoide_Bottle3()
    {
        // Instantiate(생성할 오브젝트, position, rotation)
        // Quaternion.identity = rotation(회전각)이 0,0,0 임을 의미 (회전없음)
        Instantiate(spoidebottle3, new Vector3(5.054f, -0.73f, 0), Quaternion.identity);
        spoidebottle3.SetActive(true);
        count += 1;

        Instantiate(buttonmake, new Vector3(2.68f, -3.17f, 0), Quaternion.identity);
        buttonmake.SetActive(true);
    }

}
