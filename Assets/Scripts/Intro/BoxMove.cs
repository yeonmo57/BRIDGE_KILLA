using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    Vector3 target = new Vector3(-18f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {

        yield return new WaitForSeconds(1f);
        transform.position = Vector3.Lerp(transform.position, target, 0.05f);
    }
}
