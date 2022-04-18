using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionMaker : MonoBehaviour
{
    // 포션 재료 생성
    public GameObject material1;
    public GameObject material2;
    public GameObject material3;

    public static int count = 0;

    public void Material1()
    {
        // Instantiate(생성할 오브젝트, position, rotation)
        // Quaternion.identity = rotation(회전각)이 0,0,0 임을 의미 (회전없음)
        Instantiate(material1, new Vector3(3.628f, 2.375f, 0), Quaternion.identity);
        material1.SetActive(true);
        count += 1;

    }

    public void Material2()
    {
        // Instantiate(생성할 오브젝트, position, rotation)
        // Quaternion.identity = rotation(회전각)이 0,0,0 임을 의미 (회전없음)
        Instantiate(material2, new Vector3(5.104f, 2.396f, 0), Quaternion.identity);
        material2.SetActive(true);
        count += 1;
    }

    public void Material3()
    {
        // Instantiate(생성할 오브젝트, position, rotation)
        // Quaternion.identity = rotation(회전각)이 0,0,0 임을 의미 (회전없음)
        Instantiate(material3, new Vector3(6.535f, 2.349f, 0), Quaternion.identity);
        material3.SetActive(true);
        count += 1;
    }

}
