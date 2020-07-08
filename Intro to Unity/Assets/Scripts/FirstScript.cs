using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // String variables
        string location = "Australia"; // Defining variable
        // Error: location = 5; cannot convert the variable data type
        location = "America"; // Changing value of variable
        location = "Australia"; // Redefining the variable to the first value

        // Integer variables
        int health = 50; // Setting/Defining variable
        // Error: health = "Healthy"
        health = health + 20;
        health += 20;

        // Float variable(s)
        float moveSpeed = 2.5f;
        moveSpeed -= 1.0f;

        // Boolean variables
        bool canMove = true;
        canMove = !canMove; // Inverting the boolean variable value

        // COMPARISON OPERATORS
        if(health == 50)
        {
            Debug.Log("Health is = 50");
        }
        else if(health > 50)
        {
            Debug.Log("Health is > 50");
        }
        else
        {
            Debug.Log("Health is not equal to 50 or greater than 50")
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
