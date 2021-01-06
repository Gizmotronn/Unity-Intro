using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")] // We can now create instances of Pokemon from the Unity inspector/project tab

public class PokemonBase : ScriptableObject
{
    [SerializeField] string name; // We need to use this variable outside of the class
        
    [TextArea]
    [SerializeField] string description;

    // Variables for sprites
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite; // We need both the front and back sprites of the monsters in the battle system (pocket monsters)

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    // Pokemon Stats
    [SerializeField] int maxHp;
    [SerializeField] int Attack;
    [SerializeField] int Defense;
    [SerializeField] int SpAttack;
    [SerializeField] int SpDefense;
    [SerializeField] int speed;


    /* Properties - expose private outside of class 
    public string GetName() {
        return name;
    }*/ 

    public string Name {
        get { return name; }
    }

    public string Description
    { // Specify value to be returned and then get the property
        get { return description; } // Up to 11.08 in Part 5
    }

    /*public Sprite frontSprite {
        get { return frontSprite; }
    }

    public Sprite backSprite
    { // Specify value to be returned and then get the property
        get { return backSprite; } // Up to 11.08 in Part 5
    }

    public PokemonType type1 {
        get { return type1; }
    }

    public PokemonType type2
    { // Specify value to be returned and then get the property
        get { return type2; } // Up to 11.08 in Part 5
    }

    public int MaxHp {
        get { return MaxHp; }
    }

    public int Attack
    { // Specify value to be returned and then get the property
        get { return Attack; } // Up to 11.08 in Part 5
    }

    public int Defense {
        get { return defense; }
    }

    public int SpAttack
    { // Specify value to be returned and then get the property
        get { return SpAttack; } // Up to 11.08 in Part 5
    }

    public int SpDefense
    { // Specify value to be returned and then get the property
        get { return SpDefense; } // Up to 11.08 in Part 5
    } 

    public int Speed
    { // Specify value to be returned and then get the property
        get { return Speed; } // Up to 11.08 in Part 5
    }       */
}

public enum PokemonType { // Will update this with our own list later
    none,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}