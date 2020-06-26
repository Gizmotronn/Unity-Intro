using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public float moveSpeed; // Determines how fast the ship can move
    public float rotationSpeed; // Determines how fast the ship can rotate
    private Vector3 startPosition; // Sets the start position /#/ using the property Vector3 (will go through more tutorials regarding this later)
    private Quaternion startRotation; 
    private Vector3 moveDirection;
    private bool canMove = true; // If false, we can't move the ship
    private bool isAlive = true; // Like a loop in python, as long as this is true the game continues
    [SerializeField]
    private float userHealth = 10;
    public Text Health; 

    // Use this for initialization
    /**
     * Set moveDirection to (0, 0, 0), so that the Ship does not move when the game starts running.
     * Remember the start position and rotation, to reset the Ship when it is hit.
     */
    void Start()
    {
        moveDirection = new Vector3();
        startPosition = transform.position; // In the "transform" area of the gameObject
        startRotation = transform.rotation;
        Health = GetComponent<Text>();
        Health.text = userHealth.ToString();
    }

    // Update is called once per frame
    /**
     * Check, whether the player is pushing an arrow key.
     * If this is the case, adjust moveDirection and rotation of the space ship accordingly.
     * Multiplying with Time.deltaTime makes sure that the game moves the Ship with the same speed independent of frame rate.
     */
    void Update()
    {
        if (canMove) 
        {
            if (Input.GetKey(KeyCode.UpArrow)) // If the user/player presses the up arrow
            {
                moveDirection.y = 1; // vector3 # the variable moveDirection is set to 1 in the y direction, so it moves up by 1 on the y-axis
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection.y = -1; // vector3 # the variable moveDirection is set to -1 in the y direction, so it moves down by 1 on the y-axis
            }
            if (Input.GetKey(KeyCode.LeftArrow)) // If the left arrow is pressed down
            {                                                                                                                                   // that this script is attached to
                transform.Rotate (0, -90 * Time.deltaTime * rotationSpeed, 0); // sets the "rotate" value in the "transform" area of the gameObject ^^ to "0, -90 * and the time that the key is held down multiplied by the rotation speed, & 0 /#/ Essentially changing the y rotation value and therefore the direction that the ship faces 
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate (0, 90 * Time.deltaTime * rotationSpeed, 0); // Same as above, but with 90 instead of -90 for a clockwise/anticlockwise rotation
            }
            Vector3 newPosition = transform.position; // Vector 3 --> new variable called "newPosition" that is set to what the current "transform.position" is
            newPosition += moveDirection.y * transform.forward * moveSpeed * Time.deltaTime; // ^^^^
            newPosition.z = startPosition.z; // ^^
            transform.position = newPosition; // ^
        }
        Health.text = "" + userHealth;
 
                 if(userHealth <= 0)
                 Destroy(gameObject);
    }

    /**
     * OnTriggerEnter is called when two Colliders collide.
     * If the Ship collides and was not hit before (isAlive == true) then disable all renderers to make the ship invisible.
     * The Ship cannot move when it is hit, so set canMove to false. Set isAlive to false, so it cannot be hit a second time.
     * Then disable the IonCannon, as the Ship cannot shoot when it is hit.
     * Lastly call Reset(), which will reset the Ship to the start.
     */
    public void OnTriggerEnter(Collider collider)
    {
        if (isAlive) // game loop, if true
        {
            SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
            canMove = false;
            isAlive = false;
            userHealth = userHealth - 1;
            IonCannon ionCannon = gameObject.GetComponent<IonCannon>();
            if (ionCannon)
            {
                ionCannon.SetCanShoot(false);
            }
        }
        StartCoroutine(Reset());
    }

    /**
     * Resets the Ship to its start position after 2 seconds. This is done with Coroutines and WaitForSeconds.
     * After the 2 seconds all renderers are enabled. The moveDirection is set to (0, 0, 0), so that the ship stands still when it reappears.
     * canMove and isAlive are set to true.
     * Lastly the ship's rotation and position are set to their initial values.
     */
    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            renderer.enabled = true;
        }
        moveDirection = new Vector3();
        canMove = true;
        isAlive = true;
        IonCannon ionCannon = gameObject.GetComponent<IonCannon>();
        ionCannon.SetCanShoot(true);
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}