using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBar : MonoBehaviour
{
    public Sprite killAchievement, scoreAchievement, shootAchievement;
    public Image achievement;
    public float lerpTime;
    private Vector2 initialPosition, newPosition;
    private bool slideIn = false, slideOut = false;
    private float timeStartedLerping;
    private string achievements;
    void Start()
    {
        achievements = PlayerPrefs.GetString("Achievements", ".");
        initialPosition = transform.position;
        RectTransform rect = (RectTransform)transform;
        newPosition = new Vector2(transform.position.x - rect.rect.width, transform.position.y);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Bullets", 0) == 2 * 300)
        {
            slideIn = true;
            achievement.sprite = shootAchievement;
            timeStartedLerping = Time.time;
            achievements += ", shootAchievement";
            PlayerPrefs.SetString("Achievements", achievements);
        }

        if (PlayerPrefs.GetInt("Kills", 0) == 50)
        {
            slideIn = true;
            achievement.sprite = killAchievement;
            timeStartedLerping = Time.time;
            achievements += ", killAchievement";
            PlayerPrefs.SetString("Achievements", achievements);
        }

        if (Score.score >= 300)
        {
            if (!achievements.Contains("scoreAchievement"))
            {
                slideIn = true;
                achievement.sprite = scoreAchievement;
                timeStartedLerping = Time.time;
                achievements += ", scoreAchievement";
                PlayerPrefs.SetString("Achievements", achievements);
            }
        }

        CheckSlideStatus();
    }

    private void CheckSlideStatus()
    {
        if (slideIn)
        {

            transform.position = Lerp(initialPosition, newPosition, timeStartedLerping, lerpTime);
        }

        if (slideOut)
        {

            transform.position = Lerp(newPosition, initialPosition, timeStartedLerping, lerpTime);
        }

        if (transform.position.x == newPosition.x && transform.position.y == newPosition.y)
        {
            slideIn = false;
            StartCoroutine(Wait());
        }

        if (transform.position.x == initialPosition.x && transform.position.y == initialPosition.y)
        {
            slideOut = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        slideOut = true;
        timeStartedLerping = Time.time;
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
