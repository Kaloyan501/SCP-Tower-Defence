
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private EnemyPath enemyPath;
    [SerializeField] private float spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || enemyPath == null)
            return;

        if (enemyPath.WaypointCount == 0)
            return;

        GameObject enemy = Instantiate(
            enemyPrefab,
            enemyPath.GetWaypoint(0).position,
                                       Quaternion.identity
        );

        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();

        if (movement != null)
        {
            movement.Initialize(enemyPath);
        }
        else
        {
            Debug.LogError("Enemy prefab is missing EnemyMovement!");
            Destroy(enemy);
        }
    }
}
