using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class LaserShot2 : MonoBehaviour
{
    public AudioSource bulletSource;
    public AudioClip shotSound;

    private void Start()
    {
        bulletSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {

    }
}