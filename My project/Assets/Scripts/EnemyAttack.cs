using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask forGround, forPlayer;
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkpointRange;
    public float timebetweenAttacks;
    bool beenattacked;
    public float sightRange, attackRange;
    public bool isplayerinSight, isplayerinAttackrange;
    private int whatisPlayer;

    public void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    
        
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() 
    {
        isplayerinSight = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        isplayerinAttackrange = Physics.CheckSphere(transform.position, attackRange, whatisPlayer);
        if (isplayerinSight && !isplayerinAttackrange) Patroling();
        else if (isplayerinSight && !isplayerinAttackrange) Chase();
        else if (!isplayerinAttackrange && !isplayerinSight) Attack();
    }
    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (!walkPointSet)
            agent.SetDestination(walkpoint);
        Vector3 distancewalkpoint = transform.position - walkpoint;
        if (distancewalkpoint.magnitude < 1f)
            walkPointSet = false;
    }
    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkpointRange, walkpointRange);
        float randomX = Random.Range(-walkpointRange, walkpointRange);
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.z + randomZ);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, forGround))
            walkPointSet = true;
    }
    public void Chase()
    {
        agent.SetDestination(player.position);

    }
    public void Attack()
    {
        transform.LookAt(player);

        if(!beenattacked )
        {
            beenattacked = true;
            Invoke(nameof(RestAttack), timebetweenAttacks);
        }
    }
    private void RestAttack()
    {
        beenattacked = false;
    }
}
