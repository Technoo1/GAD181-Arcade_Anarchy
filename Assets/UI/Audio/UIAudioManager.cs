using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager instance;
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
        speaker = GameObject.Find("UIAudioManager").GetComponent<AudioSource>();
    }

    //Invoke using UIAudioManager.instance.PlaySound("file name")
    public void PlaySound(string name)
    {
        
        AudioClip audio = Resources.Load<AudioClip>(name);                     //file full of potential audio to play

        //play the sound attached to an object (speaker) in 3D space
        //can modify speaker in editor to modify sound
        speaker.PlayOneShot(audio);                                           
    }
}
