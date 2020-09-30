using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    /// <summary>
    /// A reference to the spell's rigid body
    /// </summary>
    private Rigidbody2D myRigidBody;
    
    /// <summary>
    /// The spell's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// The spells target
    /// </summary>
    private Transform target;

	// Use this for initialization
	void Start ()
    {
        //Creates a reference to the spell's rigidbody
        myRigidBody = GetComponent<Rigidbody2D>();

        ///JUST FOR TESTING AND DEBUGGING
        target = GameObject.Find("Target").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Calculates the spells direction
        Vector2 direction = target.position - transform.position;

        //Moves the spell by using the rigid body
        myRigidBody.velocity = direction.normalized * speed;

        //Calculates the rotation angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Rotates the spell towards the target
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
