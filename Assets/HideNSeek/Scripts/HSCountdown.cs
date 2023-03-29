using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HSCountdown : MonoBehaviour
{
    public float timerCount = 30; //30 seconds is the default
    public TMP_Text timerText;
    public bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timerCount > 0)
            {
                timerCount -= Time.deltaTime;
            }
            else
            {
                timerCount = 0;
                timerIsRunning = false;
                Debug.Log("time's up! great living color song btw ;)");
            }
        }

        DisplayTime(timerCount);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{00}", seconds); //if I just want to show double digits in seconds with 59 being the max value
        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //if I want to include minutes in the format
    }
}