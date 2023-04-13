using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class PewPew
{
    public string name;
    public AudioClip shotSound;
    
    [Range(0f, 4f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
