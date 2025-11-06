using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.DamageTaken(damage);
            Destroy(gameObject);
        }
    }
}
