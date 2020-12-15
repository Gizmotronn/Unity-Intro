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
        if (!isMoving) {
            input.x = Input.GetAxisRaw("Horizontal"); // 10:05 ep 1 - see notion for video link
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0; // Allowing the player to move diagonally.
        }

        if (input != Vector2.zero)
        {
            var targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;

            StartCoroutine(Move(targetPos));
        }
    }

    IEnumerator Move(Vector3 targetPos) { // Do something over a period of time (IEnumerator) --> move the player over a period of time

        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) // Checks if the player is away from the target position - where we want to be
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null; // Stop the execution of the code when the player is at `targetPos`
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
