using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 10;
    public static int pickupsUsed = 0;
    public int maxPickupsPerLevel = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pickupsUsed < maxPickupsPerLevel)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null && playerHealth.health < playerHealth.maxHealth)
            {
                float healValue = Mathf.Min(healAmount, playerHealth.maxHealth - playerHealth.health);
                playerHealth.Heal(healValue);

                pickupsUsed++;

                // Optional: play sound or particle effect here

                Destroy(gameObject); // Remove the pickup from the scene
            }
        }
    }
}
