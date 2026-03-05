using UnityEngine;

public class PlayClickSound : MonoBehaviour
{
    public void OnClick()
    {
        AudioManager.Instance.Play("ClickSound");
    }
}