using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
    [Header("Zone Settings")]
    public GameObject enemyPrefab;
    public int enemiesToSpawn = 3;
    public bool respawnOnDeath = false;
    public float respawnDelay = 3f;
    public Vector3 spawnAreaSize = new Vector3(15f, 0f, 15f);

    [Header("Runtime Info (Read Only)")]
    public bool playerInside = false;
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    private Transform player;
    private float nextSpawnTime;

    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        // Clean up null enemies
        spawnedEnemies.RemoveAll(e => e == null);

        // Respawn logic
        if (playerInside && respawnOnDeath && Time.time >= nextSpawnTime && spawnedEnemies.Count < enemiesToSpawn)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + respawnDelay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            if (spawnedEnemies.Count == 0)
            {
                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    SpawnEnemy();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            0f,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
    }

    public void OnEnemyKilled(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
        if (respawnOnDeath)
            nextSpawnTime = Time.time + respawnDelay;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = playerInside ? Color.red : Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, 1f, spawnAreaSize.z));
    }
}
