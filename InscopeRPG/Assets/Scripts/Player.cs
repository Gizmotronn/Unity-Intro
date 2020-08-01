using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed; // For move speed / Adjustible in Unity inspector /#/ Set to "10" in inspector
    private Vector2 direction; // player direction

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.up;   
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    public void Move() {
        transform.Translate(direction*speed*Time.deltaTime); // Time.deltaTime = time that has passed since the last update - same movement speed on all platforms/computers --> frames/updates per second
    }

    private void GetInput()
    {
        direction = Vector2.zero; // Prevent adding speed when more keys are pressed/when keys are held down for longer        

        if (Input.GetKey(KeyCode.W)) // Get key - executed while holding down
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            direction += Vector2.right;
        }
    }
}
