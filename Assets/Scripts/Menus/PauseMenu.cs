using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverMenu.gameIsOver)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = !GameIsPaused;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        FindObjectOfType<AudioManager>().Stop(Audio.Fuel);
        Time.timeScale = 0f;
        GameIsPaused = !GameIsPaused;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = !GameIsPaused;
        Score.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
