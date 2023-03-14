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
    public Sprite PlayerPeek; //variable to place the peeking char sprite
    public Sprite PlayerHide; //variable to place the hiding char sprite
    //public Sprite GuardFront;

    void Update()
    {
        GameObject guardsFacing;
        guardsFacing = GameObject.FindWithTag("GuardFront"); //search for any guards facing the player

        if (Input.GetKeyDown(KeyCode.UpArrow)) //if up is pressed...
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PlayerPeek; //swap to peeking player sprite
            //Debug.Log("up/peek was pressed");
            {
                if (guardsFacing == true) //if there are guards facing the player...
                {
                    Destroy(this.gameObject); //kill the player for now.
                    Debug.Log("caught by guard!");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) //if down is pressed...
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PlayerHide; //swap to hiding player sprite
            //Debug.Log("down/hide was pressed");
        }
    }
}