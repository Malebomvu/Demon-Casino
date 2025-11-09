using UnityEngine;

public class Enem : MonoBehaviour
{
    public Transform target; // Rename from 'enemy' to 'target' for clarity
    public float speed = 3f;
    public float stopDistance = 1f;
    public int health = 50;
    public int damageAmount = 20;

    private float lastHitTime = 0f;
    public float hitCooldown = 1f; // seconds between hits

    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;

        if (distance > stopDistance)
        {
            Vector3 moveDir = direction.normalized;
            transform.position += speed * Time.deltaTime * moveDir;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time - lastHitTime >= hitCooldown)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                lastHitTime = Time.time;
            }
        }
    }
}
