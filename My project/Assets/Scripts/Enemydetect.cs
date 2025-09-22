using UnityEngine;

public class Enem : MonoBehaviour
{
    public Transform player;
    public float speed = 4f;
    public float stopDistance = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) return;
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        float distance = direction.magnitude;
        if(distance > stopDistance )
        {
            Vector3 moveDir = direction.normalized;
            transform.position += speed * Time.deltaTime * moveDir;
        }

    }
}
