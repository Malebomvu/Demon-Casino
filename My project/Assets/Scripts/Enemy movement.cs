using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class Enemymovement : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent Enemy;
    public float speed = 0.1f;
    public bool isChasing = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
     if (isChasing)
        {
            Enemy.SetDestination(Player.position);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
}
