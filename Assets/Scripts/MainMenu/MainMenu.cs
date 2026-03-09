using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
       PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("prefEdvin Hammer", 0);
    }

    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("prefEdvin Hammer", 0);
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
