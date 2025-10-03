using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class IntrotoMenu : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("The name of the main menu scene to load after the intro timeline finishes.")]
    public string mainMenuSceneName = "Main Menu";

    private PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();

        // Ensure the Timeline runs even if timeScale is changed
        if (director != null)
            director.timeUpdateMode = DirectorUpdateMode.UnscaledGameTime;
    }
    private void Start()
    {
        // Pause game while in intro/menu
        Time.timeScale = 0;

        // Play timeline if not already auto-playing
        if (director != null)
            director.Play();
    }

    // This will be called by a Signal Emitter at the END of the intro timeline
    public void LoadMainMenu()
    {
      
        // Load the Main Menu scene
        SceneManager.LoadScene("Main Menu");
    }
}
