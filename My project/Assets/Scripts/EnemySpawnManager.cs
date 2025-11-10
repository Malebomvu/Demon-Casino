using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Global Spawn Settings")]
    public int maxEnemiesInScene = 10; // Hard cap across all zones

    private static EnemySpawnManager instance;

    void Awake()
    {
        instance = this;
    }

    public static bool CanSpawn()
    {
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        return currentEnemies < instance.maxEnemiesInScene;
    }
}
