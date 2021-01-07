using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !GameOverMenu.gameIsOver)
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
        Time.timeScale = PlayerPrefs.GetFloat("Difficulty", 0.85f);
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
        Time.timeScale = PlayerPrefs.GetFloat("Difficulty", 0.85f);
        GameIsPaused = !GameIsPaused;
        Score.score = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
