using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class Enemymovement : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent Enemy;
    public float speed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
     if (Player != null)
        {
            Enemy.SetDestination(Player.position);
        }
    }
}
