using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player Movement
        // Horizontal movement
        GetComponent<Rigidbody2D> ().velocity = new Vector2 (
            Input.GetAxis("Horizontal") * moveSpeed, // x
            0 // y
        );
    }
}
