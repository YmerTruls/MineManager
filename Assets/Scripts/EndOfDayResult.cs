using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class EndOfDayResult : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] DialogueBox dialogueBox;
    [SerializeField] List<OreData> ores;

    public void Awake()
    {
        text.text = "Day over. You managed to collect: \n";
        foreach (OreData ore in ores) {
            if (PlayerPrefs.GetInt("quota"+ ore.OreName) > 0 ){
                text.text = text.text + PlayerPrefs.GetInt(ore.OreName);
                text.text = text.text + "/" + PlayerPrefs.GetInt("quota"+ore.OreName);
                text.text = text.text + "    " + ore.OreName + "\n";
                PlayerPrefs.SetInt("quota"+ore.OreName, 0);
                PlayerPrefs.SetInt(ore.OreName, 0);
            }
        }
        text.text = text.text + PlayerPrefs.GetString("win");

        dialogueBox.SetText(text.text);

    }
}
