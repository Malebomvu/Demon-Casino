using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    [Header("UI References")]
   
    public GameObject hudUI;
    public Slider volumeSlider;
    private bool isPaused = false;
    public bool lockCursorOnStart = true;


    void Start()
    {
        Time.timeScale = 1f;

        // Ensure UI states
        pauseMenuUI?.SetActive(false);
        settingsMenuUI?.SetActive(false);
        hudUI?.SetActive(true);

        // Handle cursor lock
        if (lockCursorOnStart)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // 🎵 Register in-game volume slider to SoundManager (if available)
        if (volumeSlider != null && SoundManager.Instance != null)
        {
            SoundManager.Instance.RegisterSlider(volumeSlider);
        }
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        if (hudUI != null) hudUI.SetActive(false);


        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if (hudUI != null) hudUI.SetActive(true);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void ResumeState()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;
    }

    public void OpenSettings()
    {
        pauseMenuUI?.SetActive(false);
        settingsMenuUI?.SetActive(true);

        // 🎚️ Ensure settings menu volume slider still works
        if (volumeSlider != null && SoundManager.Instance != null)
        {
            SoundManager.Instance.RegisterSlider(volumeSlider);
        }
    }

    public void CloseSettings()
    {
        settingsMenuUI?.SetActive(false);
        pauseMenuUI?.SetActive(true);
    }
    public void Exit()
    {
        Time.timeScale = 1f; // Unpause the game before leaving
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Go back to Main Menu scene instead of quitting
        SceneManager.LoadScene("Main Menu");
    }
}
