using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBAudioManager : MonoBehaviour
{
    public static CBAudioManager instance;
    public AudioSource speaker;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        speaker = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    //Invoke using CBAudioManager.instance.PlaySound("file name")
    public void PlaySound(string file)
    {
        AudioClip[] audio = Resources.LoadAll<AudioClip>(file);                     //file full of potential audio to play

        AudioClip audioRandom = audio[UnityEngine.Random.Range(0, audio.Length)];   //pick random sound from file

        //play the sound attached to an object (speaker) in 3D space
        //can modify speaker in editor to modify sound
        speaker.PlayOneShot(audioRandom);                                           
    }
}
