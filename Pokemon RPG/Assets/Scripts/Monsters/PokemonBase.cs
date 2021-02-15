using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")] // We can now create instances of Pokemon from the Unity inspector/project tab

public class PokemonBase : ScriptableObject
{
    [SerializeField] string  name;
    [TextArea]
    [SerializeField] string  description;

    //# Sprite fields
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    // Pokemon Types - uses enum
    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    // Base stats of Pokemon
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    // Learnable moves list
    [SerializeField] List<LearnableMove> learnableMoves; // Create list called LearnableMove 

    public string Name {
        get { return name; }
    }

    public string Description {
        get { return description; }
    }

    public Sprite FrontSprite {
        get { return frontSprite; }
    }

    public Sprite BackSprite {
        get { return backSprite; }
    }

    public PokemonType Type1 {
        get { return type1; }
    }

    public PokemonType Type2 {
        get { return type2; }
    }

    public int MaxHp {
        get { return maxHp; }
    }

    public int Attack {
        get { return attack; }
    }

    public int Defense {
        get { return defense; }
    }

    public int SpAttack {
        get { return spAttack; }
    }

    public int SpDefense {
        get { return spDefense; }
    }

    public int Speed {
        get { return speed; }
    }

    public List<LearnableMove> LearnableMoves {
        get { return learnableMoves; }
    }

}

[System.Serializable]

public class LearnableMove {
    [SerializeField] MoveBase moveBase; // Reference to MoveBase.cs script
    [SerializeField] int level;

    // Properties to expose the above variables
    public MoveBase Base { 
        get { return moveBase; }
    }

    public int Level {
        get { return level; }
    }
}

public enum PokemonType {
    None,
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

public class TypeChart {
    float [][] chart =
    {
        // Nor Fir Wat
        /*Nor*/ new float [] { 1f, 1f, 1f },
        /*For*/ new float [] { 1f,0.5f,0.5f },
        /*Wat*/ new float [] { 1f, 2f, 0.5f } 
        /*ELE*/ new float [] {}
        /*GRS*/ new float [] {}
        /*POI*/ new float [] {} //https://youtu.be/PvtHnmSy9qc?t=262
    };
}