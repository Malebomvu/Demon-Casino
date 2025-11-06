using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainStory: MonoBehaviour
{
    public Button skipButton; // Assign this in the Inspector

    private void Start()
    {
        // Optional: Hide the skip button initially or customize its appearance
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipStory);
        }

        // Start your timeline or story logic here if needed
    }

    private void OnEnable()
    {
       // SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
    public void SkipStory()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
