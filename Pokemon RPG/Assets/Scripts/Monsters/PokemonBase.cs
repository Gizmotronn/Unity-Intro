using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBase : ScriptableObject
{
    [SerializeField] string name; // We need to use this variable outside of the class
        
    [TextField]
    [SerializeField] string description;

    // Variables for sprites
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite; // We need both the front and back sprites of the monsters in the battle system (pocket monsters)
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