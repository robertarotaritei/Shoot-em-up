using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score = 0;

    public Text scoreText;

    public Text highScoreText;

    public Text finalScoreText;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void SetText()
    {
        finalScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }
    }
}
