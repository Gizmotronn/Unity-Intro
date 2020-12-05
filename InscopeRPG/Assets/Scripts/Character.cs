using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
public abstract class Character : MonoBehaviour
{

    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// A reference to the character's animator
    /// </summary>
    protected Animator myAnimator;

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    /// <summary>
    /// The Character's rigidbody
    /// </summary>
    private Rigidbody2D myRigidbody;

    /// <summary>
    /// indicates if the character is attacking or not
    /// </summary>
    protected bool isAttacking = false;

    /// <summary>
    /// A reference to the attack coroutine
    /// </summary>
    protected Coroutine attackRoutine;
    
    /// <summary>
    /// Indicates if character is moving or not
    /// </summary>
    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected virtual void Start()
    {
        //Makes a reference to the rigidbody2D
        myRigidbody = GetComponent<Rigidbody2D>();

        //Makes a reference to the character's animator
        myAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
    protected virtual void Update ()
    {
        HandleLayers();
	}

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        myRigidbody.velocity = direction.normalized * speed;
    }

    /// <summary>
    /// Makes sure that the right animation layer is playing
    /// </summary>
    public void HandleLayers()
    {
        

        //Checks if we are moving or standing still, if we are moving then we need to play the move animation
        if (IsMoving)
        {
            ActivateLayer("WalkLayer");

            //Sets the animation parameter so that he faces the correct direction
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);

            StopAttack();
        }
        else if (isAttacking)
        {
            ActivateLayer("AttackLayer");
        }
        else
        {
            //Makes sure that we will go back to idle when we aren't pressing any keys.
            ActivateLayer("IdleLayer");
        }
    }

    /// <summary>
    /// Activates an animation layer based on a string
    /// </summary>
    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName),1);
    }

    /// <summary>
    /// Stops the attack
    /// </summary>
    public void StopAttack()
    {
        isAttacking = false; //Makes sure that we are not attacking

        myAnimator.SetBool("attack", isAttacking); //Stops the attack animation

        if (attackRoutine != null) //Checks if we have a reference to an co routine
        {
            StopCoroutine(attackRoutine);

        }


    }
}
