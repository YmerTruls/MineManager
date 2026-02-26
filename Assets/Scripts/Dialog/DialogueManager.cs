using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //[SerializeField] TMP_Text textBox;
    [SerializeField] private DialogueBox dialogueBox;

    public void HideDialog()
    {
        dialogueBox.HideDialogue();
    }


    public void ShowDialogue(string text)
    {
        dialogueBox.SetText(text);
    }
}
