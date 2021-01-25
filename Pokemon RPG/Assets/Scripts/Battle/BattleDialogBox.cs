using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText; // Reference to the dialogue text
    [SerializeField] int lettersPerSecond;

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
}
