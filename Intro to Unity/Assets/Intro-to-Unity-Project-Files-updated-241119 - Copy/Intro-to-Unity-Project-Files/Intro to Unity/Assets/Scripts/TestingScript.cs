using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    void Awake ()
    {
        Debug.Log("Awake");
    }

    void Start ()
    {
        Debug.Log("Start");
    }

    void Update ()
    {
        //Debug.Log("Update every frame");
    }

    void FixedUpdate ()
    {
        //Debug.Log("Fixed update");
    }

    void LateUpdate ()
    {
        //Debug.Log("Late update");
    }

    void OnEnable ()
    {
        Debug.Log("Enabled");
    }

    void OnDisable ()
    {
        Debug.Log("Disabled");
    }
}