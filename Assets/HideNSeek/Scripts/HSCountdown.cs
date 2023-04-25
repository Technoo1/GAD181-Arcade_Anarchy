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

    public AudioSource fiveSecsRemain;
    //public bool alreadyPlayed = false;

    public GameObject ingameScr;
    public GameObject missionCompleteScr;

    public bool isGameOver;

    public GameObject Player;

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
                if (timerCount > 6)
                {
                    fiveSecsRemain.Play();
                    //PlayAudio();
                }
            }
            else
            {
                timerCount = 0; //once the timer reaches zero...
                timerIsRunning = false; //... stop the timer
                missionCompleteScr.SetActive(true); //show the "mission complete" UI
                ingameScr.GetComponent<AudioSource>().pitch = 1.0f;
                Time.timeScale = 0; //effectively pauses the game, minus audio
                StartCoroutine(GameOverScreen());
                Player.GetComponent<HSPlayerControls>().enabled = false; //disables the player controller, preventing move spam during mission completion screen
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

    //void PlayAudio()
    //{
    //    if (!alreadyPlayed)
    //    {
    //        fiveSecsRemain.Play();
    //        alreadyPlayed = true;
    //    }
    //}

    IEnumerator GameOverScreen()
    {
        TicketTier earned = TicketTier.Two;
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("time's up! great living color song btw ;)");
            yield return new WaitForSecondsRealtime(5f); //delay before displaying the game over scene
            EventManager.instance.TriggerGameOver(earned); //game over screen
        }


        //either delete timer and assign a keypress to if statement, to return to start game UI menu...
        //or return to start menu INSTEAD of the main menu scene
        //this should mean time out accrues score whereas a game over resets intel score to 0 and player gets nothing?
    }
}