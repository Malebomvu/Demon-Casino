using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio References")]
    public AudioMixer audioMixer;
    public AudioSource musicSource;

    [Header("UI References")]
    public Slider volumeSlider;

    private const string VolumePrefKey = "masterVolume";

    private void Awake()
    {
        // Singleton pattern — only one SoundManager survives across scenes
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        // Load saved volume preference
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 0.75f);
        SetVolume(savedVolume);

        if (volumeSlider != null)
            volumeSlider.value = savedVolume;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Only play background music in the main story scene
        if (scene.name == "MainStory")  // Change this name to match your actual scene
        {
            if (!musicSource.isPlaying)
                musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }

    public void SetVolume(float sliderValue)
    {
        // Convert 0–1 to decibel (-80 to 0)
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("volume", dB);

        PlayerPrefs.SetFloat(VolumePrefKey, sliderValue);
        PlayerPrefs.Save();
    }

    public void RegisterSlider(Slider newSlider)
    {
        // Link a slider (either from main menu or in-game)
        volumeSlider = newSlider;
        volumeSlider.value = PlayerPrefs.GetFloat(VolumePrefKey, 0.75f);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

}
