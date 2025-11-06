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
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 0.75f);
        SetVolume(savedVolume); // Apply volume on start
        volumeSlider.value = savedVolume;
    }

    public void SetVolume(float sliderValue)
    {
        // Convert slider value (0–1) to decibel scale (-80 to 0)
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
        mixer.SetFloat("volume", dB);

        PlayerPrefs.SetFloat(VolumePrefKey, sliderValue);
    }
}
