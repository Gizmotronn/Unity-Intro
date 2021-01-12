using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new move")]

public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp; // Number of times a move can be performed 

    public string Name {
        get { return name; }
    }

    public string Description {
        get { return description; }
    }

    public PokemonType Type {
        get { return type; }
    }

    public int Power { // Level, determines when a Pokemon (based on its level) unlcoks a new move
        get { return power; }
    }

    public int Accuracy {
        get { return accuracy; }
    }

    public int PP 
    {
        get { return pp; }
    }
}
