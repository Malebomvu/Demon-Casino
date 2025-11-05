using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Playerhealth playerhealth;
    public int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerhealth.TakeDamage(damage);
        }
    }
}
