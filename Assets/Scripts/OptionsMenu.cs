using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider _brightnessSlider;
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Image _overlay;
    [SerializeField] AudioMixer _sound;

    public void AdjustBrightness()
    {
        var color = _overlay.color;

        color.a = _brightnessSlider.value;

        _overlay.color = color;
    }


    public void AdjustVolume()
    {
        _sound.SetFloat("Volume", _volumeSlider.value);
    }
}
