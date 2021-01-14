using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is the BattleUnit Script

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit; // Determine if pokemon is the player's

    public Pokemon Pokemon { get; set; }

    public void Setup() { // Create a pokemon with the constructor of the Pokemon class
        Pokemon = new Pokemon(_base, level);
        if (isPlayerUnit)
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        else 
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
    }
}