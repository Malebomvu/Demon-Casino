using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    [Header("UI References")]
   
    public GameObject hudUI;

    private bool isPaused = false;
    public bool lockCursorOnStart = false;


    void Start()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);

        if (hudUI != null)
            hudUI.SetActive(true); // ✅ Show HUD at start

        if (lockCursorOnStart)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1f;
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
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        if (settingsMenuUI != null)
            settingsMenuUI.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsMenuUI != null)
            settingsMenuUI.SetActive(false);

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);
    }
    public void Exit()
    {
        // Go back to Main Menu scene instead of quitting
        SceneManager.LoadScene("Main Menu");
    }
}
