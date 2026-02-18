using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Dropdown dd;

    public void ValueChanged()
    {
        SceneManager.LoadScene(dd.value);
    }
}


