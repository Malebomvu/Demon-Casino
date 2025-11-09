using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour
{
    //[Header("UI References")]
    //public GameObject gameintroTitleCanvas;  // Reference to the Game Title Canvas
    public GameObject settingsscreen;
    public Slider volumeSlider;
    // public GameObject storylineCanvas;  // Reference to the Storyline Canvas

    //public float delayBeforeMenu = 5f;
    //public float storylineDuration = 5f;

    private void Start()
    {
        //gameintroTitleCanvas.SetActive(true);
        //storylineCanvas.SetActive(false);
        settingsscreen.SetActive(false);
        //gameintroTitleCanvas.SetActive(true);

       
       
    }



    public void Play()
    {
        
        // Load the game scene directly if "Play" is selected
        SceneManager.LoadScene("Demon Casino");
    }

    public void Settings()
    {
        settingsscreen.SetActive(true);
       // gameintroTitleCanvas.SetActive(false)
    }

    public void Back()
    {
        settingsscreen.SetActive(false);   // Hide settings screen
        //gameintroTitleCanvas.SetActive(true);
    }

    public void AdjustVolume(float value)
    {
        AudioListener.volume = value;            // Adjust global volume
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
