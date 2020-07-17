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

public class RendererFade : MonoBehaviour
{
    public float fadeTime;
    private Renderer[] renderers;
    private float currentTime;
    private bool fadeComplete = false;
    private bool isActive = false;

    // Use this for initialization
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void Fade()
    {
        isActive = true;
    }

    public bool IsComplete()
    {
        return fadeComplete;
    }

    // Update is called once per frame
    /**
     * When isActive is true RendererFade slowly fades out the GameObject.
     * It does so by slowly reducing the alpha value from 1 (fully opaque) to 0 (fully transparent).
     * The alpha value is calculated with Mathf.Lerp, which is a method that interpolates between two numbers.
     */ 
    void Update()
    {
        if (isActive)
        {
            currentTime += Time.deltaTime;

            if (currentTime < fadeTime)
            {
                foreach (Renderer asteroidFace in renderers)
                {
                    Color previousColor = asteroidFace.material.color;
                    float time = currentTime / fadeTime;
                    float alpha = Mathf.Lerp((float)1.0, (float)0.0, time);
                    Color newColor = new Color(previousColor.r, previousColor.g, previousColor.b, alpha);
                    asteroidFace.material.color = newColor;
                }
            }
            else
            {
                foreach (Renderer asteroidFace in renderers)
                {
                    asteroidFace.enabled = false;
                }
                isActive = false;
                fadeComplete = true;
            }
        }
    }
}
