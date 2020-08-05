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

    private Animator animator;

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    // Use this for initialization
    void Start () {
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

        // Setting walk layer (see SetLayerWeight in AnimateMovement()) - if the player's direction is actually changing/player is moving
        if (direction.x != 0 || direction.y != 0)
        {            
            //Animate's the Player's movement
            AnimateMovement(direction);
        }
        else // Set back to idle layer when object not moving
        {
            animator.SetLayerWeight(1/* Idle layer = 1st layer, 0 on index*/, 0);  // Sets walk layer weight to 0
        }
    }

    /// <summary>
    /// Makes the player animate in the correct direction
    /// </summary>
    /// <param name="direction"></param>
    public void AnimateMovement(Vector2 direction)
    {
        //Sets the animation parameter so that he faces the correct direction
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);

        // Change layer weight - idle & walk
        animator.SetLayerWeight(1 /* indexing - 2nd layer, #1 on index */, 1 /*Set the weight to = 1, i.e. for it to be showing */); // The walk layer on the player is the second overall animation layer
    }
}
