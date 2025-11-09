using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int hitsTaken = 0;
    public int maxHits = 3;

    public static int demonsKilled = 0;
    public static int totalDemons = 6; // Set this to match your level

    public GameObject winScreen; // Assign in Inspector
    public TMP_Text demonCounterText; // Assign in Inspector

    public TMP_Text killPopupText; // Assign in Inspector
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
        if (demonsKilled < totalDemons)
        {
            demonsKilled++;
            UpdateCounter();
            ShowKillPopup();
        }
        Destroy(gameObject);

        if (demonsKilled >= totalDemons && winScreen != null)
        {
            winScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

    private void UpdateCounter()
    {
        if (demonCounterText != null)
        {
            demonCounterText.text = "Demons Defeated: " + demonsKilled + " / " + totalDemons;
        }
    }

    private void ShowKillPopup()
    {
        if (killPopupText != null)
        {
            killPopupText.gameObject.SetActive(true);
            killPopupText.text = "+1 Demon Slain";
            CancelInvoke(nameof(HideKillPopup));
            Invoke(nameof(HideKillPopup), popupDuration);
        }
        else
        {
            Debug.LogWarning("Kill popup text is not assigned!");
        }
    }

    private void HideKillPopup()
    {
        killPopupText.gameObject.SetActive(false);
    }
}
