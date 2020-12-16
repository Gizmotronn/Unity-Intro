using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            input.x = Input.GetAxis("Horizontal"); // 10:05 ep 1 - see notion for video link
            input.y = Input.GetAxis("Vertical");

        if (input != Vector2.zero)
        {
            Vector3 targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;

            StartCoroutine(Move(targetPos));
        }
    }

    IEnumerator Move(Vector3 targetPos) { // Do something over a period of time (IEnumerator) --> move the player over a period of time

        if ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) // Checks if the player is away from the target position - where we want to be
        {
            isMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null; // Prevents execution of StartCoroutine(Move(_)) (see above), when the player is at `targetPos`
        }
        else isMoving = false;
        //transform.position = targetPos;
        //isMoving = false;
    }
    
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
