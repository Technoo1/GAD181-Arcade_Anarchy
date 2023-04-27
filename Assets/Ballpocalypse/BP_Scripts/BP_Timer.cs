using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BP_Timer : MonoBehaviour
{

    public float timerCount = 0;
    public bool timerIsRunning = false;
    public TMP_Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)

        {
            timerCount += Time.deltaTime;
        }

        DisplayTime(timerCount);
            
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay == 0)
        {
            timeToDisplay = 0; //force to show 0 if timer ever technically runs below 0
        }

        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{00}", seconds); //if I just want to show double digits in seconds with 59 being the max value
        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //if I want to include minutes in the format
    }
}
