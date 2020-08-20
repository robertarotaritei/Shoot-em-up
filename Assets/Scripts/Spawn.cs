using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;
    int differentEnemies = 0;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, spawnRate);
        StartCoroutine(MyCounter(enemies.Length));
        spawnRate -= 0.2f;
    }
    void SpawnEnemy()
    {

        int sideOfSpawning = Random.Range(-1, 2);
        if(sideOfSpawning == 0)
        {
            Instantiate(enemies[Random.Range(0, differentEnemies)], new Vector3(Random.Range(-8.5f, 8.5f), 7.5f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(enemies[Random.Range(0, differentEnemies)], new Vector3(sideOfSpawning * 10, Random.Range(-4.2f, 4.2f), 0), Quaternion.identity);
        }
    }

    IEnumerator MyCounter(int number)
    {
        int i = 0;
        while (i < number)
        {
            differentEnemies++;
            yield return new WaitForSeconds(15);
        }
    }
}
