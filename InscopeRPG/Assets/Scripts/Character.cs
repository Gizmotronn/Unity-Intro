using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
public abstract class Character : MonoBehaviour {

    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// A reference to the character's animator
    /// </summary>
    private Animator animator;

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
    protected virtual void Update ()
    {
        Move();
	}

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        transform.Translate(direction * speed * Time.deltaTime);

        //Checks if we are moving or standing still, if we are moving then we need to play the move animation
        if (direction.x != 0 || direction.y != 0)
        {
            //Animate's the Player's movement
            AnimateMovement(direction);
        }
        else
        {
            //Makes sure that we will go back to idle when we aren't pressing any keys.
            animator.SetLayerWeight(1, 0);
        }

    }

    /// <summary>
    /// Makes the player animate in the correct direction
    /// </summary>
    /// <param name="direction"></param>
    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);

        //Sets the animation parameter so that he faces the correct direction
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}
