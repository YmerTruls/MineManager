using TMPro;
using UnityEngine;

public class EndOfDayResult : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] DialogueBox dialogueBox;

    public void Awake()
    {
        text.text = "Day over. You managed to collect: \n" +
            PlayerPrefs.GetInt("Coal") + "     Coal \n" +
            PlayerPrefs.GetString("win");
        dialogueBox.SetText(text.text);

    }
}
