using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
    private int currentDay;
    public void nextDay() {
        currentDay = PlayerPrefs.GetInt("day");

        if (currentDay == 5)
            SceneManager.LoadScene("EndingScene");
        else
        {
            PlayerPrefs.SetInt("day", currentDay + 1);
            SceneManager.LoadScene("GameScene");
        }
    }
}
