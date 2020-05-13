/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 moveDirection;
    private bool canMove = true;
    private bool isAlive = true;

    // Use this for initialization
    /**
     * Set moveDirection to (0, 0, 0), so that the Ship does not move when the game starts running.
     * Remember the start position and rotation, to reset the Ship when it is hit.
     */
    void Start()
    {
        moveDirection = new Vector3();
        startPosition = transform.position;
        startRotation = transform.rotation;
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
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection.y = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection.y = -1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate (0, -90 * Time.deltaTime * rotationSpeed, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate (0, 90 * Time.deltaTime * rotationSpeed, 0);
            }
            Vector3 newPosition = transform.position;
            newPosition += moveDirection.y * transform.forward * moveSpeed * Time.deltaTime;
            newPosition.z = startPosition.z;
            transform.position = newPosition;
        }
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
        if (isAlive)
        {
            SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
            canMove = false;
            isAlive = false;
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
