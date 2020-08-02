using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract/* Can't add this to objects, but can add some parts of this over to other objects*/ class Character : MonoBehaviour 
{
    [SerializeField]
    private float speed; // For move speed / Adjustible in Unity inspector /#/ Set to "10" in inspector
    protected /* Can be accessed by any object with Character instead of MonoBehaviour */ Vector2 direction; // player direction

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual /* Can go into player.cs and override */void Update()
    {
        Move();
    }

    public void Move() {
        transform.Translate(direction*speed*Time.deltaTime); // Time.deltaTime = time that has passed since the last update - same movement speed on all platforms/computers --> frames/updates per second
    }
}
