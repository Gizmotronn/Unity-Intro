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

public class ScreenWrap : MonoBehaviour
{
    public Renderer[] renderers;
    private bool flipped = false;

    private bool isVisible()
    {
        bool visible = true;
        foreach (Renderer renderer in renderers)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            if (!GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
            {
                visible = false;
                break;
            }
        }
        return visible;
    }

    void Update()
    {
        bool visible = isVisible();
        if (visible)
        {
            flipped = false;
        }

        var previousPosition = transform.position;
        if (!visible && flipped == false)
        {
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            Vector3 currentPosition = transform.position;

            if (viewportPosition.x < 0 || viewportPosition.x > 1)
            {
                Vector3 screenEdge;
                if (viewportPosition.x > 1)
                {
                    screenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero);
                }
                else
                {
                    screenEdge = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1));
                }
                currentPosition.x = screenEdge.x;
            }
            if (viewportPosition.y < 0 || viewportPosition.y > 1)
            {
                Vector3 screenEdge;
                if (viewportPosition.y > 1)
                {
                    screenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero);
                }
                else
                {
                    screenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 1));
                }
                flipped = true;
                currentPosition.y = screenEdge.y;
            }
            transform.position = currentPosition;
            transform.position = new Vector3(transform.position.x, transform.position.y, previousPosition.z);
        }
    }
}
