using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;
    int differentEnemies = 0;
    public readonly static float xMax = 2f;
    public readonly static float yMax = 1.4f;

    void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(MyCounter(enemies.Length));
    }

    void SpawnEnemy()
    {

        int sideOfSpawning = Random.Range(-1, 2);
        if (sideOfSpawning == 0)
        {
            float x = Random.Range(-xMax, xMax);
            Instantiate(enemies[Random.Range(0, differentEnemies)], new Vector3(x, 2f, 0), Quaternion.identity);
        }
        else
        {
            float y = Random.Range(-yMax, yMax);
            Instantiate(enemies[Random.Range(0, differentEnemies)], new Vector3(sideOfSpawning * 3, y, 0), Quaternion.identity);
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
        while (!GameOverMenu.gameIsOver)
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
