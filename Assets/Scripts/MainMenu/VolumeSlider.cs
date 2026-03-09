using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    public void SliderUpdated()
    {
        AudioManager.Instance.updateVolume(slider.value);
    }
}
