using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] powerUps;
    public GameObject appear;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    void SpawnPowerUp()
    {
        float x = Random.Range(-EnemySpawner.xMax, EnemySpawner.xMax);
        float y = Random.Range(-EnemySpawner.yMax, EnemySpawner.yMax - 0.4f);

        Instantiate(powerUps[Random.Range(0, powerUps.Length)], new Vector3(x, y, 0), Quaternion.identity);
        Instantiate(appear, new Vector3(x, y, 0), Quaternion.identity);

        FindObjectOfType<AudioManager>().Play(Audio.PowerUp);
    }

    IEnumerator Spawner()
    {
        while (!GameOverMenu.gameIsOver)
        {
            int chance = Random.Range(0, 10);
            Debug.Log(chance);
            if (chance < 8)
            {
                SpawnPowerUp();
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
