using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] float enemySpawnFrequency;
    float enemySpawnTimer;

    [SerializeField] Transform[] pickupPrefabs;
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
        var enemy = Instantiate(pickupPrefabs[Random.Range(0,pickupPrefabs.Length)], new Vector3(Random.Range(-10, 10), 5.5f, (renderDistance * 50) + playerMovement.playerPosition.z + Random.Range(-20, 20)), Quaternion.Euler(0f, 0f, transform.parent.rotation.z), transform);
        enemySpawnTimer = enemySpawnFrequency * Random.Range(0.15f, 1f);
    }
}
