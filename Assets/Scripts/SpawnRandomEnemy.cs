using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;

    public Transform spawnArea;

    public float minDistanceToPlayer = 10f;

    public int maxEnemies = 10;
    private int currentEnemies = 0;

    public float spawnCooldown = 2f;
    private float currentCooldown = 0f;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currentEnemies = enemies.Length;
        if (currentEnemies < maxEnemies && currentCooldown <= 0)
        {
            SpawnEnemy();
            currentCooldown = spawnCooldown;
        }

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        if (player != null && enemyPrefab != null && spawnArea != null)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();

            if (Vector3.Distance(spawnPosition, player.transform.position) >= minDistanceToPlayer)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                currentEnemies++;
            }
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Collider spawnCollider = spawnArea.GetComponent<Collider>();
        Vector3 center = spawnCollider.bounds.center;
        Vector3 size = spawnCollider.bounds.size;
        float randomX = Random.Range(-size.x / 2, size.x / 2);
        float randomZ = Random.Range(-size.z / 2, size.z / 2);

        Vector3 spawnPos = center + new Vector3(randomX, 2f, randomZ);

        return spawnPos;
    }
}