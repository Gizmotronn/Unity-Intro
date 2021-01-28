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
    int currentAction;

    private void Start() {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle() {
        playerUnit.Setup(); // Creates player Pokemon
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        dialogBox.EnableActionSelector(false);
        dialogBox.EnableMoveSelector(false);

        yield return dialogBox.TypeDialog($"A wild {playerUnit.Pokemon.Base.Name} appeared."); // Wait for this to be complete before changing the state
        yield return new WaitForSeconds(1f); // Wait for 1 second

        PlayerAction(); // Let the player select an action
    }

    void PlayerAction() { // When it is the player's turn:
        state = BattleState.PlayerAction; // set the state of battle to the Player action
        StartCoroutine(dialogBox.TypeDialog("Choose an action")); // Replace the dialog text
        dialogBox.EnableActionSelector(true); // Pass true as an argument/parameter so the dialog box is enabled
    }

    private void Update() {
        if (state == BattleState.PlayerAction) {
            HandleActionSelection();
        }
    }

    void HandleActionSelection() {
        if (input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
                ++currentAction;
        }
        else if (input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }

        // Update selection in UI
    }
}
