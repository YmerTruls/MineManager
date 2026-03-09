using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private DialogueBox dialogueBox;

    public void Awake()
    {
        text.text += "Your performance has decided the fate of the workers.\n\n";

        int fails = PlayerPrefs.GetInt("fail");

        if (fails >= 4)
        {
            text.text += "You got the bad ending.";
        }

        else
        {
            text.text += "You got the good ending.";
        }
    }

}
