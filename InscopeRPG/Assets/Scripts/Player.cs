using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character // MonoBehaviour /-/ Now the player is also a character
{
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.up;   
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();

        // Override Character.cs Update() for player movement
        base.Update();
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
