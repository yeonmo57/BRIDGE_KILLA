using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovePractice : MonoBehaviour
{
    public GameObject targetPosition;
    Vector3 vel = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition.transform.position, ref vel, 0.8f);
    }
}
