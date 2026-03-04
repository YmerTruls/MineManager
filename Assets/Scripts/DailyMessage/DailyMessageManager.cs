using UnityEngine;
using TMPro;

public class DailyMessageManager : MonoBehaviour
{
    private int day;
    public TMP_Text DailyMessageText;
    
    public void Awake()
    {
        day = PlayerPrefs.GetInt("day");

    }

    public void SetDailyMessage(string message)
    {
        DailyMessageText.SetText(message);
    }
}
