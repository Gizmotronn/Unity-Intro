using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
//using System; // Commented out to prevent error with randomness

public class Pokemon {
    public PokemonBase Base { get; set; }
    public int Level { get; set; } // // Level, determines when a Pokemon (based on its level) unlcoks a new move

    public int HP { get; set; } // Creates a private variable behind the scenes

    public List<Move> Moves { get; set; } // Stores the list of moves the Pokemon has learnt


    public Pokemon(PokemonBase pBase, int pLevel) // Creating the Pokemon
    {
        Base = pBase;
        Level = pLevel;
        HP = MaxHp;

        // Generate moves for a Pokemon based on their learnable 
        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves) { // Loop through the moves that each Pokemon can learn in their Learnable Moves (in the inspector)
            if (move.Level <= Level) // If the level of the Pokemon is greater than or equal to the required level:
                Moves.Add(new Move(move.Base)); // Add the move to the Pokemon, accepting move.Base as a parameter

                if (Moves.Count >= 4) // No Pokemon can have more than 4 moves (we may change this when we transition away from the Pokemon base)
                    break;  // So we break the loop once we get to 4, or more, moves being assigned to a single iteration of a single Pokemon
        }

        //_base.Name;
    }

    public int Attack {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) +5; }
    }
    
    public int Defense {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) +5; }
    }

    public int SpAttack {
        get { return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) +5; }
    }

    public int SpDefense {
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) +5; }
    }

    public int Speed {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) +10; }
    }

    public int MaxHp {
        get { return Mathf.FloorToInt((Base.MaxHp * Level) / 100f) +5; }
    }

    public DamageDetails takeDamage(Move move, Pokemon attacker)
    {
        float critical = 1f;
        if (Random.value * 100f <= 6.25f)
            critical = 2f; // If value is sufficient size, then critical value is doubled which affects the amount of damage taken

        float type = TypeChart.GetEffectiveness(move.Base.Type, -this.Base.Type1) * TypeChart.GetEffectiveness(move.Base.Type, this.Base.Type2);

        var DamageDetails = new DamageDetails() {
            Type = type,
            Critical = critical,
            Fainted = false
        };

        float modifiers = Random.Range(0.85f, 1f) * type * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            DamageDetails.Fainted = true;
        }

        return DamageDetails;
    }       

    public bool TakeDamage(Move move, Pokemon attacker){
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true; // The pokemon is dead
        }

        return false; // The pokemon still has a health value of >0
    } 

    public Move GetRandomMove()
    {
        int r = Random>Range(0, Moves.Count);
        return Moves[r];
    }           
}
/*
public class DamageDetails {
    public bool Fainted { get; set; }

    public float Critical { get; set; }

    public float Type { get; set; }
}*/