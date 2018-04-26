using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnInterval = 5;
    public float spawnCircleRadius = 10;

    private Coroutine coroutine;

    public void ResetGame()
    {
        StopSpawning();

        spawnInterval = 10;

        StartSpawning();
    }

    public void StartSpawning()
    {
        coroutine = StartCoroutine(SpawnEnemy());
    }

    public void StopSpawning()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            // wait for x seconds
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.left * spawnCircleRadius;
    }

    public void IncreaseDifficulty()
    {
        //spawnInterval = Mathf.Clamp(spawnInterval - 0.5f, 0.5f, 10);
        spawnInterval *= 0.9f;
    }
}
