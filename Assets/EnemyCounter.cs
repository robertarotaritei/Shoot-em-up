using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public GameObject enemyLeft;
    public GameObject enemyRight;
    public GameObject enemyTop;
    public static int enemiesLeft = 0;
    public static int enemiesRight = 0;
    public static int enemiesTop = 0;

    void Start()
    {
        enemyLeft.SetActive(false);
        enemyRight.SetActive(false);
        enemyTop.SetActive(false);
    }

    void Update()
    {
        UpdateIndicator();
    }

    private void UpdateIndicator()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyLeft.SetActive(false);
        enemyRight.SetActive(false);
        enemyTop.SetActive(false);

        foreach (var enemy in enemies)
        {
            if (enemy.transform.position.y > EnemySpawner.yMax)
            {
                enemyTop.SetActive(true);
            }

            if (enemy.transform.position.x < -EnemySpawner.xMax)
            {
                enemyLeft.SetActive(true);
            }

            if (enemy.transform.position.x > EnemySpawner.xMax)
            {
                enemyRight.SetActive(true);
            }
        }
    }
}
