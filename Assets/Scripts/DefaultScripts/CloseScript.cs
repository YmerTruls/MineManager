using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void Close()
    {
        panel.SetActive(false);
        AudioManager.Instance.Play("FormSound");
    }
}

