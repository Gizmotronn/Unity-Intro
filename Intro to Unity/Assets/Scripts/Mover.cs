using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Attach this script to the 'capsule` game object

public class Mover : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        // Create vector3
        //Vector3 newPos = new Vector3(5, 2, -2); // 5, 2, -2 = transform.position values for game object this script is attached to for the Vector3
        //transform.position = newPos;
        transform.position += new Vector3(0.1f, 01f, 0.1f); // every frame this object moves like this
        transform.position += new Vector3(0.1f, 01f, 0.1f); * Time.deltaTime; // every second rather than every frame
        transform.position += Vector3.one * Time.deltaTime; // .one = x, y, z
        transform.position += new Vector3(0.1f, 01f, 0.1f) * Time.deltaTime * moveSpeed; // define moveSpeed in the inspector
        transform.position += transform.forward * Time.deltaTime * moveSpeed; // Move capsule in its forward direction
    }
}
