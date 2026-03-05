using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        PlayerPrefs.SetInt("day", 0);
        PlayerPrefs.SetInt("fail", 0);
        PlayerPrefs.SetInt("success", 0);


    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
