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