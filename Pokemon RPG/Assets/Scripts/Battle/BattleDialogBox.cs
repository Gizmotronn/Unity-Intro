using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;

    [SerializeField] Text dialogText; // Reference to the dialogue text
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;
    
    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts; // Player will select from a LIST of actions and moves

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;


    public void SetDialog(string dialog){
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray()) {
            dialogText.text += letter; // After adding each letter wait
            yield return new WaitForSeconds(1f/lettersPerSecond);//30); // Wait for 1/30th of a second after adding each letter. 
        }
    }

    public void EnableDialogText(bool enabled) {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void EnableMoveSelector (bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction) {
        for (int i=0; i<actionTexts.Count; ++i) {// Loop through action text list
            if (i == selectedAction)
                actionTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;
        }
    }

    public void UpdateMoveSelection(int selectedMove, Move move)
    {
        for (int i=0; i<actionTexts.Count; ++i)
        {
            if (i == selectedMove)
                moveTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;
        }

        ppText.text = $"PP {move.PP}/15";//"{move.BasePP}";
        typeText.text = move.Base.Type.ToString(); // Turn the enum to a string
    }

    public void SetMoveNames(List<Move> moves) {
        for (int i=0; i<moveTexts.Count; ++i) {
            if (i < moves.Count) // Some pokemon may have 2, 3 or 4 moves. So we add new move text labels until the number of moves that have labels is equal to moves.count, or the total number of moves
                moveTexts[i].text = moves[i].Base.Name;
            else
            {
                moveTexts[i].text = "-"; // Move text is empty
            }            
        }
    }
}
