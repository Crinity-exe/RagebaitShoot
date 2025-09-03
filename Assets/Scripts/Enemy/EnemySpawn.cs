using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private WallMovement[] wallPrefabs;

    [SerializeField] private float enemySpawnInterval;
    [SerializeField] private float wallSpawnInterval;
    private float enemySpawnTimer;
    private float wallSpawnTimer;

    private void Start()
    {
        enemySpawnTimer = enemySpawnInterval;
        wallSpawnTimer = wallSpawnInterval;
    }
    private void FixedUpdate()
    {
        if (enemySpawnTimer > 0)
        {
            enemySpawnTimer -= Time.deltaTime;
        }
        if (enemySpawnTimer <= 0)
        {
            StartCoroutine(EnemiesSpawn());
            enemySpawnTimer = enemySpawnInterval;
        }
        if (wallSpawnTimer > 0)
        {
            wallSpawnTimer -= Time.deltaTime;
        }
        if (wallSpawnTimer <= 0)
        {
            StartCoroutine(WallSpawn());
            wallSpawnTimer = wallSpawnInterval;
        }
    }
    private IEnumerator EnemiesSpawn()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            EnemyMovement enemyMovement = Instantiate(enemyPrefab, spawnPoints[i].transform.position, Quaternion.identity);
            enemyMovement.playerTarget = playerTarget;
        }
        yield return new WaitForSeconds(enemySpawnInterval);
    }

    private IEnumerator WallSpawn()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomWall = Random.Range(0, wallPrefabs.Length);
            WallMovement wallMovement = Instantiate(wallPrefabs[randomWall], spawnPoints[i].transform.position, Quaternion.identity);
            wallMovement.playerTarget = playerTarget;
        }
        yield return new WaitForSeconds(wallSpawnInterval);
    }
}
