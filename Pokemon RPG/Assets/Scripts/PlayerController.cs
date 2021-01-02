using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask grassLayer;

    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

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
            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);

            Vector3 targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;

            if (IsWalkable(targetPos))
                StartCoroutine(Move(targetPos));
        }else
        {
            animator.SetBool("isMoving", false);
        }
    }

    IEnumerator Move(Vector3 targetPos) { // Do something over a period of time (IEnumerator) --> move the player over a period of time

        if ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) // Checks if the player is away from the target position - where we want to be
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null; // Prevents execution of StartCoroutine(Move(_)) (see above), when the player is at `targetPos`
        }
        else isMoving = false;

        CheckForEncounters();
    }
    
    private bool IsWalkable(Vector3 targetPos) { // Check if the tile position is walkable
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null) // Tile is not walkable if the IF statement is not null, as there is something at that Vector3 position // Solid objects layer as third parameter
        { 
            return false;
        }

        return true; // Call Move Coroutine if we return true
    }

    private void CheckForEncounters() 
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null) 
        { // If not null the player is walking in the long grass aka in contact with a gameObject with LongGrass layer
            if (Random.Range(1,101) <= 10) // 1 in 10 times when the player walks on grass he will trigger a battle with a "pokemon"
            {
                Debug.Log("Encountered a wild alien!");
            }
    }
    } // https://stackoverflow.com/questions/61567592/first-time-using-c-it-says-i-have-error-cs1513#:~:text=Compiler%20Error%20CS1513means%20that%20there%20are%20not%20enough,the%20file.%20You%20should%20have%20three%20of%20them.
}