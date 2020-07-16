using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Attach this script to the 'capsule` game object

public class Mover : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
       transform.position += transform.forward * moveSpeed * Time.deltaTime; 

       if(transform.position.z >= 3 || transform.position.z <= -3)
       {
           moveSpeed = -moveSpeed;
       }
      // else if(transform.position.z <= -3)
       //{
        //   moveSpeed = -moveSpeed
       //}
    }
}
