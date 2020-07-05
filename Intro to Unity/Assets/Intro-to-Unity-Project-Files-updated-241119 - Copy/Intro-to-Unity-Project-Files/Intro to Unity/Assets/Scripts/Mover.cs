using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed;
    public float moveDistance;

    // Update is called once per frame
    void Update ()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;

        if(transform.position.x >= moveDistance || transform.position.x <= -moveDistance)
        {
            moveSpeed = -moveSpeed;
        }
    }
}
