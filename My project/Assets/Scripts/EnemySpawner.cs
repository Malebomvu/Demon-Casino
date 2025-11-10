using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;          // Your enemy prefab (assign in Inspector)
    public int maxEnemiesInScene = 6;       // How many demons can exist at once
    public bool respawnOnDeath = false;     // Should a new one spawn when one dies?

    [Header("Spawn Area Settings")]
    public Vector3 spawnAreaSize = new Vector3(30f, 0f, 30f); // Width/Depth of spawn zone
    public float minSpawnDistance = 3f;     // Prevents enemies spawning too close to each other

    [Header("Spawn Timing")]
    public float spawnDelay = 1f;           // Delay before spawning next enemy
    private float nextSpawnTime;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        SpawnInitialEnemies();
    }

    void Update()
    {
        // Clean up destroyed enemies
        spawnedEnemies.RemoveAll(enemy => enemy == null);

        // Optionally respawn
        if (respawnOnDeath && Time.time >= nextSpawnTime && spawnedEnemies.Count < maxEnemiesInScene)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnInitialEnemies()
    {
        for (int i = 0; i < maxEnemiesInScene; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab not assigned in EnemySpawner!");
            return;
        }

        Vector3 spawnPos = GetRandomSpawnPosition();

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
    }

    Vector3 GetRandomSpawnPosition()
    {
        int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                0f,
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            bool tooClose = false;
            foreach (GameObject enemy in spawnedEnemies)
            {
                if (enemy == null) continue;
                if (Vector3.Distance(enemy.transform.position, randomPos) < minSpawnDistance)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
                return randomPos;
        }

        // fallback
        return transform.position;
    }

    // Call this from the EnemyHealth script when an enemy dies (optional)
    public void OnEnemyKilled(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);
        if (respawnOnDeath)
            nextSpawnTime = Time.time + spawnDelay;
    }

    // Debug Gizmos — shows spawn area in scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, 1f, spawnAreaSize.z));
    }
}
