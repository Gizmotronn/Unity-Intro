using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy } // List of "states"

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit; // the playerUnit game object
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;
    int currentMove;

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

        dialogBox.SetMoveNames(playerUnit.Pokemon.Moves); // Takes function from `BattleDialogBox.cs`

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.Pokemon.Base.Name} appeared."); // Wait for this to be complete before changing the state
        yield return new WaitForSeconds(1f); // Wait for 1 second

        PlayerAction(); // Let the player select an action
    }

    void PlayerAction() { // When it is the player's turn:
        state = BattleState.PlayerAction; // set the state of battle to the Player action
        StartCoroutine(dialogBox.TypeDialog("Choose an action")); // Replace the dialog text
        dialogBox.EnableActionSelector(true); // Pass true as an argument/parameter so the dialog box is enabled
    }

    void PlayerMove() {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;

        var move = playerUnit.Pokemon.Moves[currentMove];
        yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.Base.Name} used {move.Base.Name}");
        yield return new WaitForSeconds(1f);

        bool isFainted = enemyUnit.Pokemon.TakeDamage(move, PlayerUnit.Pokemon);

        if (isFainted) {
            yield return dialogBox.TypeDialog($"{enemyUnit.Pokemon.Base.Name} fainted");
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove() {
        state = BattleState.EnemyMove;
    }

    private void Update() {
        if (state == BattleState.PlayerAction) {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }

    void HandleActionSelection() {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {                
                // Fight
                PlayerMove();
            }

            else if (currentAction == 1) {
                // Run
            }
        }

        // Update selection in UI
        dialogBox.UpdateActionSelection(currentAction);
    }

    void HandleMoveSelection() {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Pokemon.Moves.Count - 1)
                ++currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 0)
                --currentMove;
        }

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Pokemon.Moves[currentMove]);
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
