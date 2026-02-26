using TMPro;
using UnityEngine;

public class EndOfDayResult : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void Awake()
    {
        text.text = "Day over. You managed to collect: \n" +
            PlayerPrefs.GetInt("Coal") + "     Coal \n" +
            PlayerPrefs.GetString("win");
    }
}
