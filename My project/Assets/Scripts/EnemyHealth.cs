using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public void DamageTaken(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            DemonKilled();
        }

    }
    private void DemonKilled()
    {
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
