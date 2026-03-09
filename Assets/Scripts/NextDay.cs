using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
    private int currentDay;
    public void nextDay() { 
        currentDay = PlayerPrefs.GetInt("day");
        PlayerPrefs.SetInt("day", currentDay + 1);
        SceneManager.LoadScene("GameScene");
    }
}
