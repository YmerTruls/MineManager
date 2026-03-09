using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public void OnClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
