using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pokemon {
    PokemonBase _base;
    int level;

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;

        //_base.Name;
    }

    public int Attack {
        get { return Math.FloorToInt((_base.Attack * level) / 100f) +5; }
    }
    
    public int Defense {
        get { return Math.FloorToInt((_base.Defense * level) / 100f) +5; }
    }

    public int SpAttack {
        get { return Math.FloorToInt((_base.SpAttack * level) / 100f) +5; }
    }

    public int SpDefense {
        get { return Math.FloorToInt((_base.SpDefense * level) / 100f) +5; }
    }

    public int MaxHp {
        get { return Math.FloorToInt((_base.MaxHp * level) / 100f) +5; }
    }

    public int Speed {
        get { return Math.FloorToInt((_base.Speed * level) / 100f) +10; }
    }                    
}