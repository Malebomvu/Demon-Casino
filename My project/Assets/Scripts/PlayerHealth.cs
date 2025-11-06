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

    void Start()
    {
        deathScreen.SetActive(false);
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        damagePopupText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hud.SetActive(false);
            inv.SetActive(false);
            deathScreen.SetActive(true);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthSlider.value = health;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        ShowDamagePopup("-" + damageAmount + " HP");
        healthSlider.value = health;
    }

    private void ShowDamagePopup(string message)
    {
        damagePopupText.text = message;
        damagePopupText.gameObject.SetActive(true);
        Invoke(nameof(HideDamagePopup), 2f);
    }

    private void HideDamagePopup()
    {
        damagePopupText.gameObject.SetActive(false);
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
            health = maxHealth;

        healthSlider.value = health;
    }
}
