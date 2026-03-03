using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Coroutine _setDialogCoroutine;

    private WaitForSeconds _popupDelay;
    //[SerializeField] TMP_Text textBox;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private float popupDelay = 2;

    private void Awake()
    {
        _popupDelay = new WaitForSeconds(popupDelay);
    }

    public void HideDialog()
    {
        if (_setDialogCoroutine != null)
            StopCoroutine(_setDialogCoroutine);

        dialogueBox.HideDialogue();
    }


    public void ShowDialogue(string text)
    {
        _setDialogCoroutine = StartCoroutine(DelayedDialoge(text));
    }

    IEnumerator DelayedDialoge(string text)
    {
        yield return _popupDelay;

        dialogueBox.SetText(text);
    }
}
