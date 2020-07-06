using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        logLevel();

        //int level = 1; 
        //Debug.Log(level);
    }

    void logLevel() 
    {
        int level = 2;
        Debug.Log(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
