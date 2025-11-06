using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
   // private float damageRange;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;

   

    public AudioClip[] sounds;
    private AudioSource source;


    void Start()
    {
        //damageRange = Random.Range(minDamage, maxDamage);
        source = player.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageSet);
            }
        }

    }


}
