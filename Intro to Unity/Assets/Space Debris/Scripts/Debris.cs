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

[RequireComponent (typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(SphereCollider))]
[RequireComponent (typeof(RendererFade))]

public class Debris : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speed;
    public AudioClip explosionSound;
    private AudioSource audioSrc;
    private float zPosition;
    private bool isDestroyed = false;
    private RendererFade renderFade;
    private bool beganFade = false;

    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        renderFade = GetComponent<RendererFade>();
        float rotate = Random.Range(0, 180);
        speed = Random.Range(minSpeed, maxSpeed);
        transform.Rotate(rotate, rotate, 0);
        zPosition = transform.position.z;
    }

    // Update is called once per frame
    /**
     * Updates the position of the Debris.
     * When isDestroyed is true, because the Debris collided with another GameObject, Update fades out the Debris and destroys it once it is fully transparent.
     */
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition += transform.forward * speed * Time.deltaTime;
        newPosition.z = zPosition;
        transform.position = newPosition;
        if (isDestroyed)
        {
            if (!beganFade)
            {
                beganFade = true;
                renderFade.Fade();
            }
            if (renderFade.IsComplete())
            {
                Destroy(gameObject);
            }
        }
    }

    /**
     * OnTriggerEnter is called then two Colliders collide. In this case the Debris can collide with other Debris, the Ship or Bullets.
     * When that happens, play a short sound and set isDestroyed to trigger the fade out of the Debris.
     */
    public void OnTriggerEnter(Collider collider)
    {
        if (!isDestroyed)
        {
            audioSrc.PlayOneShot(explosionSound);
            isDestroyed = true;
        }
    }
}
