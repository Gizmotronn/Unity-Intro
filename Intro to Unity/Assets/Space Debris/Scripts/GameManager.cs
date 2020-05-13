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

public class GameManager : MonoBehaviour
{
    public GameObject[] debris;
    public float minTime;
    public float maxTime;
    public int totalItemsOnScreen;
    public GameObject screenDebris;
    private float randomTime;
    private float curTime;

    // Use this for initialization
    /**
     * Get a random time at which to spawn the first Debris
     */
    void Start()
    {
        randomTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    /**
     * Spawn Debris when time interval is bigger than randomTime and there is less Debris than totalItemsOnScreen.
     * If there is more than one model in debris[], the game will use this to randomize how the Debris looks.
     */
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > randomTime && screenDebris.transform.childCount < totalItemsOnScreen)
        {
            Vector3 spawnPoint = screenDebris.transform.position;
            int index = (int)Random.Range(0, debris.Length);
            GameObject debrisItem = Instantiate(debris[index], spawnPoint, Quaternion.identity) as GameObject;
            Vector3 newPosition = debrisItem.transform.position;
            debrisItem.transform.position = newPosition;
            debrisItem.transform.parent = screenDebris.transform;
            newPosition.z = 0;
            curTime = 0;
        }
    }
}
