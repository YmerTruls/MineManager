using UnityEngine;

public class NextButton : MonoBehaviour
{
    public void OnClick()
    {
        AudioManager.Instance.Play("ClickSound");
    }
}
