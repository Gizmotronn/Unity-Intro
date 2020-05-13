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

public class IonCannon : MonoBehaviour
{
    public Rigidbody bullet;
    public AudioClip fireSound;
    private AudioSource audioSrc;
    private bool canShoot = true;

    /**
     * Allow to enable and disable the IonCannon
     */
    public void SetCanShoot(bool canShoot)
    {
        this.canShoot = canShoot;
    }

    // Use this for initialization
    /**
     * Retrieve the AudioSource component, to play a fireSound with it later.
     * This is a small optimization so you do not need to call GetComponent during Update, as it is relatively expensive.
     */
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    /**
     * If player pushes Space key and canShoot is true, play a sound and create a new Bullet, which you shoot away from the player
     */
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canShoot)
            {
                audioSrc.PlayOneShot(fireSound);
                Rigidbody newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody;
                newBullet.velocity = transform.forward * 100.0f;
            }
        }
    }
}
