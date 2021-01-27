using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy } // List of "states" or sequences in the battle scene

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit; // the playerUnit game object
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;

    private void Start() {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle() {
        playerUnit.Setup(); // Creates player Pokemon
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        yield return dialogBox.TypeDialog($"A wild {playerUnit.Pokemon.Base.Name} appeared."); // Wait for this to be complete before changing the state
        yield return new WaitForSeconds(1f); // Wait for 1 second

        PlayerAction(); // Let the player select an action
    }

    void PlayerAction() { // When it is the player's turn:
        state = BattleState.PlayerAction; // set the state of battle to the Player action
        StartCoroutine(dialogBox.TypeDialog("Choose an action")); // Replace the dialog text
        dialogBox.EnableActionSelector(true); // Pass true as an argument/parameter so the dialog box is enabled
    }
}
