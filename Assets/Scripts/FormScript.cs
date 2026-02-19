using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class FormScript : MonoBehaviour
{
    [SerializeField] private GameObject FormPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FormPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void ShowPanel()
    {
        FormPanel.SetActive(true);
    }
    void HidePanel()
    {
        FormPanel.SetActive(false);
    }

    public void TogglePanel()
    {
        FormPanel.SetActive(!FormPanel.activeSelf);
    }
}
