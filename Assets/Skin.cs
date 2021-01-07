using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public Image defaultSkin, whiteSkin, overlordSkin;
    public GameObject blocked;
    private string skin;
    private bool permission = false;

    void Start()
    {
        skin = PlayerPrefs.GetString("Skin", "default");
        SwitchSkin(skin);

        var achievements = PlayerPrefs.GetString("Achievements", ".");
        permission = achievements.Contains("scoreAchievement") && achievements.Contains("shootAchievement") && achievements.Contains("killAchievement");
        blocked.SetActive(!permission);
    }

    public void SwitchSkin(string skin)
    {
        defaultSkin.color = new Color(0, 0, 0);
        whiteSkin.color = new Color(0, 0, 0);
        overlordSkin.color = new Color(0, 0, 0);

        switch (skin)
        {
            case "default":
                defaultSkin.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case "white":
                whiteSkin.color = new Color(0.5f, 0.5f, 0.5f);
                break;
            case "overlord":
                overlordSkin.color = new Color(0.5f, 0.5f, 0.5f);
                break;
        }

        PlayerPrefs.SetString("Skin", skin);
    }
}
