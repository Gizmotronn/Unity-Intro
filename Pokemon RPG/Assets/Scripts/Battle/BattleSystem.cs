using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit; // the playerUnit game object
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    private void Start() {
        SetupBattle();
    }

    public void SetupBattle() {
        playerUnit.Setup(); // Creates player Pokemon
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        StartCoroutine(dialogBox.TypeDialog($"A wild {playerUnit.Pokemon.Base.Name} appeared."));
    }
}
