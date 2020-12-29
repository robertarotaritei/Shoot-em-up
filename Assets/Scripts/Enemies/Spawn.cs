using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;
    int differentEnemies = 0;

    void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(MyCounter(enemies.Length));
    }

    void SpawnEnemy()
    {

        int sideOfSpawning = Random.Range(-1, 2);
        if(sideOfSpawning == 0)
        {
            Instantiate(enemies[Random.Range(0, differentEnemies)], new Vector3(Random.Range(-3f, 3f), 3f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(enemies[Random.Range(0, differentEnemies)], new Vector3(sideOfSpawning * 5, Random.Range(-3f, 3f), 0), Quaternion.identity);
        }
    }

    IEnumerator MyCounter(int number)
    {
        int i = 0;
        while (i < number)
        {
            differentEnemies++;
            i++;
            yield return new WaitForSeconds(15);
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            SpawnEnemy();
            if (spawnRate > 0.9f)
            {
                spawnRate -= 0.05f;
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
