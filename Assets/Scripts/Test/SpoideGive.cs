using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoideGive : MonoBehaviour
{
    //제조화면 어둡게 처리
    public GameObject blackscreen;

    public void BlackScreen()
    {
        // Instantiate(생성할 오브젝트, position, rotation)
        // Quaternion.identity = rotation(회전각)이 0,0,0 임을 의미 (회전없음)

        Instantiate(blackscreen, new Vector3(10.02f, 0.07f, 0), Quaternion.identity);
        blackscreen.SetActive(true);
    }
}
