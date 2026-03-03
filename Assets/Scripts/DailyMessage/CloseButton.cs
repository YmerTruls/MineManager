using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public void OnClick()
    {
        AudioManager.Instance.Play("ClickSound");
    }
}
