using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemyPool))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Enemy[] enemyPrefabs;

    private Vector3[] spawnPoints;
    private Coroutine spawnCoroutine;
    private EnemyPool enemyPool;

    private void Start()
    {
        enemyPool = GetComponent<EnemyPool>();

        spawnPoints = GetComponentsInChildren<Transform>()
            .Skip(1)
            .Select((spawnPoint) => spawnPoint.position)
            .ToArray();

        StartSpawn();
    }

    public void StartSpawn()
    {
        if (spawnCoroutine == null)
            spawnCoroutine = StartCoroutine(SpawnEmemys());        
    }
    public void StopSpawn()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
        
    }
    private IEnumerator SpawnEmemys()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(spawnDelay);
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            Vector3 spawnPosition = GetRandomPoint();
            Enemy prefab = GetRandomPrefab();
            enemyPool.GetEnemy(prefab, spawnPosition, Quaternion.identity);

            yield return waitForSeconds;
        }

    }
    private Enemy GetRandomPrefab()
    {
        int prefabNumber = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[prefabNumber];
    }
    private Vector3 GetRandomPoint()
    {
        int spawnPointNumber = Random.Range(0, spawnPoints.Length);
        return spawnPoints[spawnPointNumber];
    }
}
