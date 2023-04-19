using ArcadeAnarchy;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

//key press to peek DONE
//different key press to hide DONE
//swap out peeking and hiding sprites with each other per respective key press DONE

//ARCADE MACHINE button press(es) to do same as above
//key press to collect Intel, and only when player is peeking

public class HSPlayerControls : MonoBehaviour
{
    public Sprite playerPeek; //variable to place the peeking char sprite
    public Sprite playerHide; //variable to place the hiding char sprite

    public GameObject intelSpawner1; //define parent(s) of intel that spawns in, so that we can trigger more spawns
    public GameObject intelSpawner2;
    public GameObject intelSpawner3;

    public GameObject Spawns; //spawn point parent object
    public GameObject ingameScreen; //ingame ui object(s)

    public float timeTillGameOver = 3f; //time to wait before game over scene triggers, allows for additional animations, effects, etc.

    public GameObject Countdown; //the mission timer

    public AudioSource audioIfCaught;
    public bool alreadyPlayed = false;

    public AudioSource audioIfPeeking;
    public AudioSource audioIfHiding;

    void Update()
    {
        GameObject guardFacing;
        guardFacing = GameObject.FindWithTag("GuardFront"); //search for any guards facing the player

        bool playerIsPeeking = gameObject.GetComponent<SpriteRenderer>().sprite == playerPeek; //playerPeek Sprite must be active

        GameObject intelIsHere;
        intelIsHere = GameObject.FindWithTag("Intel"); //search Intel present in the scene

        if (Input.GetKeyDown(KeyCode.W)) //if W is pressed...
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerPeek; //swap to peeking player sprite
            audioIfPeeking.Play();
            //Debug.Log("up/peek was pressed");
        }
        if (Input.GetKeyDown(KeyCode.S)) //if S is pressed...
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerHide; //swap to hiding player sprite
            audioIfHiding.Play();
            //Debug.Log("down/hide was pressed");
        }
        if (guardFacing == true && playerIsPeeking == true) //if there are guards facing a peeking player...
        {
            Countdown.GetComponent<HSCountdown>().timerIsRunning = false; //stops the mission timer
            PlayAudio();
            StartCoroutine(GameOverScreen()); //basically preventing the game over screen from appearing for x seconds

            //EventManager.instance.TriggerGameOver(); //triggers universal game over screen and menu
            //Debug.Log("caught by guard! Snake? Snaaaaaake!");

            //Spawns.SetActive(false); //disables spawned objects on screen
            //ingameScreen.SetActive(false); //disable ingame ui
            //Destroy(gameObject); //TEST. "kill" player for now, if seen
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerIsPeeking == true && intelIsHere == true) //if the player presses Space while peeking...
        {
            //add an intel point (to be converted to ticket later, or just add to ticket number straight away)
            //Destroy(intelIsHere); //remove the Intel sprite from the scene
            intelIsHere.SetActive(false); //disable Intel sprite
            //Debug.Log("intel collected!");

            intelSpawner1.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script
            //intelSpawner2.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script
            //intelSpawner3.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script


            //sets the referenced object i.e. the spawn point to disable in hierarchy. NEEDS TESTING
            //try disabling the IntelSpawn class in spawn points, then have a spawn point script reenable the script again?
        }
    }

    void PlayAudio()
    {
        if (!alreadyPlayed)
        {
            audioIfCaught.Play();
            alreadyPlayed = true;
        }
    }

    IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(timeTillGameOver);
        EventManager.instance.TriggerGameOver(); //triggers universal game over screen and menu
        Debug.Log("Y O U D I E D");
    }
}