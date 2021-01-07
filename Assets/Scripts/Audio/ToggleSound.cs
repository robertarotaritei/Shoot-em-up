using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    public Text text;
    private string status;

    void Start()
    {
        status = PlayerPrefs.GetInt("Sound", 1) == 1 ? "On" : "Off";
    }

    public void ToggleSoundOnOff()
    {
        status = status == "On" ? "Off" : "On";
        text.text = status;
    }
}
