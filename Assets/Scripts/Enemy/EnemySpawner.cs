using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;


    [Header("Spawn Settings")]
    [SerializeField] private float startSpawnTime = 0f; 
    [SerializeField] private float spawnInterval = 5f;


    [Header("Spawn Area")]
    [SerializeField] private Vector2 areaSize = new Vector2(10, 3);


    [Header("Limit")]
    [SerializeField] private int maxEnemy = 3;


    private int currentEnemy;


    private void Start()
    {
        StartCoroutine(StartSpawner());
    }


    IEnumerator StartSpawner()
    {
        // صبر تا 1:45
        yield return new WaitForSeconds(startSpawnTime);


        while (true)
        {
            if (currentEnemy < maxEnemy)
            {
                SpawnEnemy();
            }


            yield return new WaitForSeconds(spawnInterval);
        }
    }



    void SpawnEnemy()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2)
        );


        Vector3 spawnPosition = transform.position + (Vector3)randomPosition;


        GameObject enemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );


        currentEnemy++;


        EnemyDeath death = enemy.GetComponent<EnemyDeath>();

        if (death != null)
        {
            death.OnDeath += EnemyKilled;
        }
    }



    void EnemyKilled()
    {
        currentEnemy--;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(
            transform.position,
            areaSize
        );
    }
}