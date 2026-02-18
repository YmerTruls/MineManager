using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Dropdown dd;

    public void ValueChanged()
    {
        SceneManager.LoadScene(dd.value);
    }
}

