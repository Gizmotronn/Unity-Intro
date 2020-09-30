using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{

    /// <summary>
    /// The actual image that we are chaing the fill of
    /// </summary>
    private Image content;

    /// <summary>
    /// A reference to the value text on the bar
    /// </summary>
    [SerializeField]
    private Text statValue;

    /// <summary>
    /// Hold the current fill value, we use this, so that we know if we need to lerp a value
    /// </summary>
    private float currentFill;

    /// <summary>
    /// The lerp speed
    /// </summary>
    [SerializeField]
    private float lerpSpeed;

    /// <summary>
    /// The stat's maxValue for example max health or mana
    /// </summary>
    public float MyMaxValue { get; set; }

    /// <summary>
    /// The currentValue for example the current health or mana
    /// </summary>
    private float currentValue;

    /// <summary>
    /// Proprty for setting the current value, this has to be used every time we change the currentValue, so that everything updates correctly
    /// </summary>
    public float MyCurrentValue
    {
        get
        {

            return currentValue;
        }

        set
        {
            if (value > MyMaxValue)//Makes sure that we don't get too much health
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0) //Makes sure that we don't get health below 0
            {
                currentValue = 0;
            }
            else //Makes sure that we set the current value withing the bounds of 0 to max health
            {
                currentValue = value;
            }

            //Calculates the currentFill, so that we can lerp
            currentFill = currentValue / MyMaxValue;

            //Makes sure that we update the value text
            statValue.text = currentValue + " / " + MyMaxValue;
        }
    }




    // Use this for initialization
    void Start()
    {
        //Creates a reference to the content
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Makes sure that we update the bar
        HandleBar();
    }

    /// <summary>
    /// Initialises the bar
    /// </summary>
    /// <param name="currentValue">The current value of the bar</param>
    /// <param name="maxValue">The max value of the bar</param>
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }

    /// <summary>
    /// Makes sure that the bar updates
    /// </summary>
    private void HandleBar()
    {
        if (currentFill != content.fillAmount) //If we have a new fill amount then we know that we need to update the bar
        {
            //Lerps the fill amount so that we get a smooth movement
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }

    }
}
