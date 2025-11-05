using UnityEngine;


public class Bullet : MonoBehaviour
{
    public string Enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.TryGetComponent <Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(10);
        } 
    }
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

}


