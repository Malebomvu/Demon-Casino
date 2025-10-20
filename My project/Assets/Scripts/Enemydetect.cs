using UnityEngine;

public class Enem : MonoBehaviour
{
    public Transform enemy;
    public float speed = 3f;
    public float stopDistance = 1f;
    public int health = 50;
    public GameObject Enemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null) return;
        Vector3 direction = enemy.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;
        if(distance > stopDistance )
        {
            Vector3 moveDir = direction.normalized;
            transform.position += speed * Time.deltaTime * moveDir;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }
   
    
}
