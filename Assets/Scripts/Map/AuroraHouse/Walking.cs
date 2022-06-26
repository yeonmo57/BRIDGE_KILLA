using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{

    Vector3 destination = new Vector3(-3.83f, -2.85f, 0);
    bool walk = false;

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            Vector3.MoveTowards(transform.position, destination, 1);
        }   
    }

    public void PlayerWalk()
    {
        walk = true;
    }
}
