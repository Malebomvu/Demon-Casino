using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameObject hud;
    public GameObject inv;
    public GameObject deathScreen;
    public GameObject player;
    public Slider healthSlider;

    public float health = 100f;
    public float maxHealth = 100f;

    public TMP_Text damagePopupText;
    public FPController playerController;

    private bool isDead = false;
    private Coroutine popupRoutine;

    void Start()
    {
        if (deathScreen != null) deathScreen.SetActive(false);
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
        if (damagePopupText != null) damagePopupText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isDead && health <= 0)
        {
            Die();
        }

        if (health > maxHealth)
            health = maxHealth;

        if (healthSlider != null)
            healthSlider.value = health;
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDead) return;

        health -= damageAmount;
        healthSlider.value = health;

        ShowDamagePopup($"-{damageAmount:F0} HP");
    }

    private void ShowDamagePopup(string message)
    {
        if (damagePopupText == null) return;

        damagePopupText.text = message;
        damagePopupText.gameObject.SetActive(true);

        if (popupRoutine != null)
            StopCoroutine(popupRoutine);
        popupRoutine = StartCoroutine(HidePopupAfterDelay(2f));
    }

    private IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        damagePopupText.gameObject.SetActive(false);
        popupRoutine = null;
    }

    private void Die()
    {
        isDead = true;
        health = 0;

        if (playerController != null)
        {
            playerController.enabled = false;
            playerController.UnlockCursor();
        }

        if (hud != null) hud.SetActive(false);
        if (inv != null) inv.SetActive(false);
        if (deathScreen != null) deathScreen.SetActive(true);
    }

    private void HideDamagePopup()
    {
        damagePopupText.gameObject.SetActive(false);
    }

    public void Heal(float healAmount)
    {

        if (isDead) return;

        health += healAmount;
        if (health > maxHealth)
            health = maxHealth;

        if (healthSlider != null)
            healthSlider.value = health;
    }
    public void Respawn()
    {
        health = maxHealth;
        isDead = false;

        if (playerController != null)
        {
            playerController.enabled = true;
            playerController.LockCursor();
        }

        if (hud != null) hud.SetActive(true);
        if (inv != null) inv.SetActive(true);
        if (deathScreen != null) deathScreen.SetActive(false);

        if (healthSlider != null)
            healthSlider.value = health;
    }

}
