using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSIntelCollectable : MonoBehaviour
{
    float intelValue = 1;
    public GameObject audioPrefab;
    private HSCountdown Countdown; //reference to the timer
    public int timeAdded;

    void Start()
    {
        Countdown = GameObject.FindGameObjectWithTag("HSTimer").GetComponent<HSCountdown>(); //finding the timer to be referenced
    }

    void OnDestroy()
    {
        HSIntelScore.playerIntel += intelValue; //adds to my Intel score
        Instantiate(audioPrefab); //plays IntelGet audio
        Countdown.timerCount += timeAdded; //adds x time to the timer
        //Debug.Log("collected " + intelValue + " Intel");
    }
}