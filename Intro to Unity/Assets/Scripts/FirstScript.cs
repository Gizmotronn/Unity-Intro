using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour // Monobehaviour is a class created by Unity - inheritance (takes on stuff from that)
{
    // Start is called before the first frame update
    void Start()
    {
        Weapon sword = new Weapon();
        sword.weaponName = "Sword";
        sword.SetDamage(8);
    }

    int weaponDamage = sword.GetDamage;

    // Update is called once per frame
    void Update()
    {
        
    }
}

Create weapons
public class Weapon
{
    public string weaponName;
    private int damage; // Can't be modified outside of this class

    public void SetDamage  (int damageToSet) // Allow for the damage to be modified externally /#/ Function // can also add ", string damageType"
    {
        damage = damageToSet
    } // void because not returning anything

    // Function to return to us the value of damage
    public int GetDamage ()
    {
        return damage; // When this function is called, we will return the damage (i.e. the damage of the weapon --> weaponDamage)
    } // int because you're returning an int value/variable
}