using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    [SerializeField]
    private float speed; 
    protected Vector2 direction;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>; 
    }

    
    protected virtual void Update()
    {
        Move();
    }

    public void Move() {
        transform.Translate(direction*speed*Time.deltaTime); 
        AnimateMovement();
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetFloat("x",direction.x);
        animator.SetFloat("y",direction.y);
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract/* Can't add this to objects, but can add some parts of this over to other objects class Character : MonoBehaviour 
{
    [SerializeField]
    private float speed; // For move speed / Adjustible in Unity inspector /#/ Set to "10" in inspector
    protected /* Can be accessed by any object with Character instead of MonoBehaviour  Vector2 direction; // player direction

    // Animate variables
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>; 
    }

    // Update is called once per frame
    protected virtual /* Can go into player.cs and override void Update()
    {
        Move();
    }

    public void Move() {
        transform.Translate(direction*speed*Time.deltaTime); // Time.deltaTime = time that has passed since the last update - same movement speed on all platforms/computers --> frames/updates per second
        AnimateMovement();
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetFloat("x",direction.x);
        animator.SetFloat("y",direction.y);
    }
}
*/
