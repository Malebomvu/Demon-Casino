using UnityEngine;

public class Enemydamage1 : MonoBehaviour
{
    public float damage = -10f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Demons"))
        {
            Debug.Log("Demon was hit");
        }
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
