using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content; // Image content

    private float currentFill; // Current amount the fill is at for the image (for each game object this script is attached to)
    private float currentValue;
    private float MyCurrentValue; // Current value - e.g. if we have 50 health, we have 50 value
    {
        get
        {
            return currentValue; // Read the value - check if player (for health) is dead or alive
        }

        set
        {
            if (value > MyMaxValue)
            {
                currentValue =  MyMaxValue;
            }
            //currentValue = value; // Set it - control/change it
        }
    }
    public float MyMaxValue { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>(); // Reference image attached to game object that stat.cs is attached to
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MyCurrentValue)
    }
}
