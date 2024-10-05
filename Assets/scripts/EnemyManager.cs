using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Transform> enemies = new List<Transform>();
    [SerializeField] float enemySpawnFrequency;
    float enemySpawnTimer;

    [SerializeField] Transform enemyPrefab;
    [SerializeField] float renderDistance = 10f;

    private void Update()
    {
        enemySpawnTimer -= Time.deltaTime;
        if (enemySpawnTimer <= 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-10, 10), 2.5f, (renderDistance * 50) + playerMovement.playerPosition.z + Random.Range(-20, 20)), Quaternion.Euler(0f, 0f, transform.parent.rotation.z), transform);
        enemies.Add(enemy);
        enemySpawnTimer = enemySpawnFrequency * Random.Range(0.15f, 1f);
    }
}
