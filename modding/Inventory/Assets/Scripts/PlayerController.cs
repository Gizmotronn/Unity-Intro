using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float health;
    public Text healthDisplay;

    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVelocity;

    // For Random Encounters Logic
    public LayerMask treeLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        healthDisplay.text = health.ToString();

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        CheckForEncounters();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void CheckForEncounters() 
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, treeLayer) != null) 
        { // If not null the player is walking in the long grass aka in contact with a gameObject with LongGrass layer
            /*if (Random.Range(1,101) <= 10) // 1 in 10 times when the player walks on grass he will trigger a battle with a "pokemon"
            {
                Debug.Log("Encountered a wild alien!");
            }*/
            Debug.Log("Encountered a wild alien!");
        }
    }
}
