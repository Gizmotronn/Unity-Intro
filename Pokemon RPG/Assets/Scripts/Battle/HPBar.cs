using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health; // health gameObject on the HPBar in the Unity Game Engine

    /*private void Start() {
        health.transform.localScale = new Vector3(0.5f, 1f); // Change x scale to 0.5, y scale stays the same at 1
    }*/

    public void SetHP(float hpNormalized) {
        health.transform.localScale = new Vector3(hp, 1f);
    }
}
