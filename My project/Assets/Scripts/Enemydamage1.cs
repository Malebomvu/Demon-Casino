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
}
