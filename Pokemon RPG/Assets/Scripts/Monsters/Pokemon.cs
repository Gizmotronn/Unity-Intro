using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonBase _base; 
    int level; // Level of the Pokemon

    public Pokemon(PokemonBase pBase, int pLevel){
        _base = pBase;
        _level = pLevel; // OOP like in Python based on attributes of a class, in this case a class instance of a "Pokemon"

        _base.name;
    }

    // Calculate the value of the stats depending on the level
    public int Attack {
        get { return Math.FloorToInt((_base.Attack * level) / 100f) + 5; }  // Bulbapedia formula
    }

    public int Defense {
        get { return Math.FloorToInt((_base.Defense * level) / 100f) + 5; } 
    }

    public int SpAttack {
        get { return Math.FloorToInt((_base.SpAttack * level) / 100f) + 5; } 
    }

    public int SpDefense {
        get { return Math.FloorToInt((_base.SpDefense * level) / 100f) + 5; } 
    }

    public int MaxHp {
        get { return Math.FloorToInt((_base.MaxHp * level) / 100f) + 10; } 
    }
}