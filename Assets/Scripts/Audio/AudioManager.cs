using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        var value = PlayerPrefs.GetFloat("Volume", 1f);

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = value;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play(Audio.Theme);
    }

    public void Play(Audio a)
    {
        var s = Array.Find(sounds, sound => sound.name == a.ToString());

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(Audio a)
    {
        var s = Array.Find(sounds, sound => sound.name == a.ToString());

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    public void SetVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);

        foreach (var s in sounds)
        {
            s.source.volume = value;
        }
    }
}
