﻿using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public bool loop;

    [Range(0f, 1f)]
    [HideInInspector]
    public float volume;

    [HideInInspector]
    public AudioSource source;
}
