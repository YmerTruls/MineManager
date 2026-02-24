using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //[SerializeField] TMP_Text textBox;
    [SerializeField] private DialogueBox dialogueBox;

    void Start()
    {
        //textBox.SetText("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogue(string text)
    {
        dialogueBox.SetText(text);
    }
}
