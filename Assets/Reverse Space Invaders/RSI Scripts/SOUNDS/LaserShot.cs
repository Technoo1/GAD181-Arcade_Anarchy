using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class LaserShot : MonoBehaviour
{
    public PewPew[] lasershooting;

    private void Awake() 
    {
        foreach(PewPew Pew in lasershooting)
        {
            Pew.source = gameObject.AddComponent<AudioSource>();
            Pew.source.clip = Pew.shotSound;

            Pew.source.volume = Pew.volume;
            Pew.source.pitch = Pew.pitch;
            Pew.source.loop = Pew.loop;
        }
    }

    public void Play(string name)
    {
        // PewPew Pew = Array.Find(lasershooting, shot => shot.name == name);
        // Pew.source.Play();
    }
    
    // public AudioClip shotSound;

    //     private void Awake() 
    // {
    //     gameObject.AddComponent<AudioSource>();
    // }

    // public void Play(string name)
    // {

    // }
}
