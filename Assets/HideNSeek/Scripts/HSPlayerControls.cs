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


    void Update()
    {
        GameObject guardFacing;
        guardFacing = GameObject.FindWithTag("GuardFront"); //search for any guards facing the player

        bool playerIsPeeking = gameObject.GetComponent<SpriteRenderer>().sprite == playerPeek; //playerPeek Sprite must be active

        GameObject intelIsHere;
        intelIsHere = GameObject.FindWithTag("Intel"); //search Intel present in the scene

        if (Input.GetKeyDown(KeyCode.UpArrow)) //if up is pressed...
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerPeek; //swap to peeking player sprite
            //Debug.Log("up/peek was pressed");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) //if down is pressed...
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerHide; //swap to hiding player sprite
            //Debug.Log("down/hide was pressed");
        }
        if (guardFacing == true && playerIsPeeking == true) //if there are guards facing a peeking player...
        {
            //trigger a game over screen?
            Destroy(gameObject); //"kill" player for now, if seen
            Debug.Log("caught by guard! Snake? Snaaaaaake!");
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerIsPeeking == true && intelIsHere == true) //if the player presses a key/button while peeking...
        {
            //add an intel point (to be converted to ticket later, or just add to ticket number straight away)
            Destroy(intelIsHere); //remove the Intel sprite from the scene
            //Debug.Log("intel collected!");

            intelSpawner1.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script
            intelSpawner2.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script
            intelSpawner3.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script


            //sets the referenced object i.e. the spawn point to disable in hierarchy. NEEDS TESTING
            //try disabling the IntelSpawn class in spawn points, then have a spawn point script reenable the script again?
        }
    }
}