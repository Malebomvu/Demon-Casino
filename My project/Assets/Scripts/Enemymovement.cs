using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class Enemymovement : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator; // optional if you have animations

    [Header("Movement Settings")]
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float patrolRange = 5f;
    public float patrolSpeed = 1.5f;
    public float chaseSpeed = 3.5f;

    [Header("Attack Settings")]
    public float attackDamage = 10f;
    public float attackCooldown = 1.5f;
    private float nextAttackTime = 0f;

    private Vector3 startPoint;
    private Vector3 patrolTarget;

    [SerializeField]
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        startPoint = transform.position;
        SetNewPatrolTarget();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // --- Chase Logic ---
        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
        {
            isChasing = true;
            agent.speed = chaseSpeed;
            agent.stoppingDistance = attackRange - 0.2f;
            agent.SetDestination(player.position);

            if (animator) animator.SetBool("isWalking", true);
        }
        // --- Attack Logic ---
        else if (distanceToPlayer <= attackRange)
        {
            isChasing = false;
            agent.ResetPath();

            transform.LookAt(player.position);

            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackCooldown;
                AttackPlayer();
            }

            if (animator) animator.SetBool("isWalking", false);
        }
        // --- Patrol Logic ---
        else
        {
            isChasing = false;
            Patrol();
        }
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;
        agent.stoppingDistance = 0f;

        if (!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            SetNewPatrolTarget();
        }

        agent.SetDestination(patrolTarget);

        if (animator) animator.SetBool("isWalking", true);
    }

    void SetNewPatrolTarget()
    {
        // Random patrol point around the starting position
        Vector2 randomPoint = Random.insideUnitCircle * patrolRange;
        patrolTarget = new Vector3(startPoint.x + randomPoint.x, startPoint.y, startPoint.z + randomPoint.y);
    }

    void AttackPlayer()
    {
        if (animator) animator.SetTrigger("Attack");
        Debug.Log("Enemy attacks player for " + attackDamage + " damage");

        // Example: Apply damage if player has PlayerHealth
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(attackDamage);
        }
    }

    // For debugging in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, patrolRange);
    }
}
