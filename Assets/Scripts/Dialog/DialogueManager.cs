using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{


    private WaitForSeconds _popupDelay;
    //[SerializeField] TMP_Text textBox;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private float popupDelay = 1;

    private void Awake()
    {
        _popupDelay = new WaitForSeconds(popupDelay);
    }

    public void HideDialog()
    {
        dialogueBox.HideDialogue();
    }


    public void ShowDialogue(string text)
    {
        StartCoroutine(DelayedDialoge(text));
    }

    IEnumerator DelayedDialoge(string text)
    {
        yield return _popupDelay;

        dialogueBox.SetText(text);
    }
}
