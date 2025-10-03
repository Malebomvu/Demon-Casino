using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    private bool isPaused = false;


    void Start()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        if (settingsMenuUI != null)
            settingsMenuUI.SetActive(false);


        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }




    void Update()
    {
        if (Input.GetButtonDown("pause")) // Make sure "pause" is mapped in Input Manager
        {
            Debug.Log("P is pressed");
            if (isPaused)
                Resume();
            else
                Pause();
        }

    }
    void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }
    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1;
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
