using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit; // the playerUnit game object
    [SerializeField] BattleHud playerHud;

    private void Start() {
        SetupBattle();
    }

    public void SetupBattle() {
        playerUnit.Setup(); // Creates player Pokemon
        playerHud.SetData(playerUnit.Pokemon);
    }
}
