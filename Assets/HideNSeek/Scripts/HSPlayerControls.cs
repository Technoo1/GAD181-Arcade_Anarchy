using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PlayerPeek; //swap player sprite to peek
            //Debug.Log("up/peek was pressed");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PlayerHide; //swap player sprite to hide
            //Debug.Log("down/hide was pressed");
        }
    }
}