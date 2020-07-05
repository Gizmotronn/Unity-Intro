using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Weapon sword = new Weapon();
        sword.weaponName = "Sword";
        sword.SetDamage(8);

        int weaponDamage = sword.GetDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Weapon
{
    public string weaponName;
    private int damage;

    public void SetDamage (int damageToSet)
    {
        damage = damageToSet;
    }

    public int GetDamage ()
    {
        return damage;
    }
}