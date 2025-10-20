using UnityEngine;

public class SceneSanityCheck : MonoBehaviour
{
    void Awake()
    {
        // Make sure main menu doesn't keep the world paused or cursor locked
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
