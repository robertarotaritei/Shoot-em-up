using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Text killRequirement, scoreRequirement, shootRequirement;
    public Image killImage, scoreImage, shootImage;
    void Start()
    {
        killRequirement.text = "Kill 50 enemies \n Progress: " + PlayerPrefs.GetInt("Kills", 0);
        scoreRequirement.text = "Get a score of at least 300 \n Progress: " + PlayerPrefs.GetInt("HighScore", 0);
        shootRequirement.text = "Shoot 300 times \n Progress: " + PlayerPrefs.GetInt("Bullets", 0) / 2;

        var achievements = PlayerPrefs.GetString("Achievements", ".");

        if (!achievements.Contains("scoreAchievement"))
        {
            scoreImage.color = new Color(0.3f, 0.3f, 0.3f);
        }

        if (!achievements.Contains("shootAchievement"))
        {
            shootImage.color = new Color(0.3f, 0.3f, 0.3f);
        }

        if (!achievements.Contains("killAchievement"))
        {
            killImage.color = new Color(0.3f, 0.3f, 0.3f);
        }
    }
}
