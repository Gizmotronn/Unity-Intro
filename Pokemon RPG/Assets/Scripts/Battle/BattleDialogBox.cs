using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText; // Reference to the dialogue text
    [SerializeField] int lettersPerSecond;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;
    
    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts; // Player will select from a LIST of actions and moves

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

    [SerializeField] Color highlightedColor;


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

    public void UpdateActionSelection(int selected) {
        // Loop through action text list
        for (int i=0; i<actionTexts.Count; ++i) {
            if (i == selectedAction)
                actionTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;
        }

        dialogBox.UpdateActionSelection(currentAction);
    }
}
