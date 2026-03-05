using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public void OnClick()
    {
        AudioManager.Instance.Play("PickSound");
    }
}
