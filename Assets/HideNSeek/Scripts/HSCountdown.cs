using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HSCountdown : MonoBehaviour
{
    public float timerCount = 30; //30 seconds is the default
    public TMP_Text timerText; //time remaining displayed
    public bool timerIsRunning = false; //is the timer still running?

    void Start()
    {
        timerIsRunning = true; //run countdown once active
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timerCount > 0)
            {
                timerCount -= Time.deltaTime; //run down the numbers
            }
            else
            {
                timerCount = 0; //once the timer reaches zero...
                timerIsRunning = false; //... stop the timer
                EventManager.instance.TriggerGameOver(); //game over screen
                Debug.Log("time's up! great living color song btw ;)");
            }
        }
        DisplayTime(timerCount);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0; //force to show 0 if timer ever technically runs below 0
        }

        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{00}", seconds); //if I just want to show double digits in seconds with 59 being the max value
        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //if I want to include minutes in the format
    }
}