using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int hitsTaken = 0;
    public int maxHits = 3;

    [Header("Game Stats")]
    public static int demonsKilled = 0;
    public static int totalDemons = 6; // Set this to match your level

    [Header("UI References")]
    public GameObject winScreen; 
    public TMP_Text demonCounterText;
    public TMP_Text killPopupText;

    [Header("Popup Settings")]
    public float popupDuration = 1.5f;

    private bool isDead = false; // Prevent double kill
    void Start()
    {
        UpdateCounter();
    }



    public void DamageTaken(float damage)
    {
        if (isDead) return; //Ignore if already dead

        hitsTaken++;
        if (hitsTaken >= maxHits)
        {
            DemonKilled();
        }
    }

    private void DemonKilled()
    {
        if (isDead) return; // Prevent double execution
        isDead = true;

        // Increment global kill counter
        demonsKilled++;
        UpdateCounter();
        ShowKillPopup();

        // Destroy enemy object
        Destroy(gameObject);

        // Check if all demons are defeated
        if (demonsKilled >= totalDemons && winScreen != null)
        {
            WinGame();
        }
    }

    private void UpdateCounter()
    {
        if (demonCounterText != null)
        {
            demonCounterText.text = $"Demons Defeated: {demonsKilled} / {totalDemons}";
        }
        else
        {
            Debug.LogWarning("Demon counter text is not assigned in Inspector!");
        }
    }

    private void ShowKillPopup()
    {
        if (PopUpManager.Instance != null)
        {
            PopUpManager.Instance.ShowPopup("+1 Demon Slain", popupDuration);
        }
        else
        {
            Debug.LogWarning("KillPopupManager instance not found. Assign a KillPopupManager in the scene.");
        }
    }

    private void HideKillPopup()
    {
        if (killPopupText != null)
            killPopupText.gameObject.SetActive(false);
    }

    private void WinGame()
    {
        winScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
