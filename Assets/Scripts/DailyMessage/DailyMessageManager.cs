using UnityEngine;
using TMPro;

public class DailyMessageManager : MonoBehaviour
{
    public TMP_Text DailyMessageText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDailyMessage(string message)
    {
        DailyMessageText.SetText(message);
    }
}
