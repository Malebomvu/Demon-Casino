using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;  // Needed to reference the slider

public class SettingsScript : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;

    private const string VolumePrefKey = "masterVolume";

    void Start()
    {
        // Load saved volume (or default to 0 dB if none is saved)
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 0f);
        mixer.SetFloat("volume", savedVolume);
        volumeSlider.value = savedVolume;
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
    }
}
