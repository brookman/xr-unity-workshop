using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnInterval = 5;
    public float spawnCircleRadius = 10;

    public void ResetGame()
    {
        StopSpawning();

        spawnInterval = 10;

        StartSpawning();
    }

    public void StartSpawning()
    {
       // TODO
    }

    public void StopSpawning()
    {
        // TODO
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
        // TODO
    }
}
