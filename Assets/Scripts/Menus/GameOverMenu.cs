using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public GameObject score;
    public static bool gameIsOver = false;

    void Update()
    {
        if (gameIsOver)
        {
            FindObjectOfType<Score>().SetText();
            gameOverMenuUI.SetActive(true);
            score.SetActive(false);
        }
    }

    public void Restart()
    {
        gameIsOver = false;
        gameOverMenuUI.SetActive(false);
        score.SetActive(true);
        Score.score = 0;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        gameIsOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
