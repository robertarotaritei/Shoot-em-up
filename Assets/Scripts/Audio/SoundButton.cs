using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite soundEnabled, soundDisabled;
    public Text text;
    public Button soundButton;

    void Awake()
    {
        soundButton.image.sprite = PlayerPrefs.GetInt("Sound", 1) == 1 ? soundEnabled : soundDisabled;
        text.text = PlayerPrefs.GetInt("Sound", 1) == 1 ? "On" : "Off";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeSound();
        }
    }

    public void ChangeSound()
    {
        AudioListener.volume = 1 - AudioListener.volume;
        PlayerPrefs.SetInt("Sound", Convert.ToInt32(AudioListener.volume));

        soundButton.image.sprite = AudioListener.volume == 1 ? soundEnabled : soundDisabled;
        text.text = AudioListener.volume == 1 ? "On" : "Off";
    }
}
