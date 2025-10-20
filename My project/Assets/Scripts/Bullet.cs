using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int damage = -10;
    public Enem Enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag =="Enemy")
        {
            Enemy = other.gameObject.GetComponent<Enem>();
            Enemy.health = Enemy.health - 10;
            Destroy(gameObject);
        }
        
    }
}
