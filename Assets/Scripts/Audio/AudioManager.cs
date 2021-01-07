using UnityEngine;
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

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.spatialBlend = 0f;
            s.source.volume = 0.75f;
            s.source.loop = s.loop;
        }

        AudioListener.volume = PlayerPrefs.GetInt("Sound", 1);
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
}
