using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBAudioManager : MonoBehaviour
{
    public static CBAudioManager instance;
    public AudioSource Speaker;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void Start()
    {
        Speaker = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        Debug.Log(Speaker);
        PlaySound("Miss");
    }

    public void PlaySound(string file) //Input, passing a string to anything listening
    {
        //OnUpdateUI?.Invoke(file);

        AudioClip[] audio = Resources.LoadAll<AudioClip>(file);

        AudioClip AudioRandom = audio[UnityEngine.Random.Range(0, audio.Length)];

        //UnityEngine.Random.Range(0, 10);
        Speaker.PlayOneShot(AudioRandom);
        //audioRandom[UnityEngine.Random.Range(0, audioRandom.Length)];
    }
}
