using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseHealth : MonoBehaviour
{
    public int horseHearts = 4;
    public List<GameObject> hearts;

    public BoxCollider2D bxCollider;
    public bool isPaused = false;
    public AudioSource damageSound;
    public AudioSource pickupSound;

    public Camera mainCamera;
    private ScreenShake screenShake;
    private GameObject DistanceObject;
    private DistanceManager distanceManagerScript;

    public bool isDead = false;
    public bool gameOverLoaded = false;
    void Start()
    {
        screenShake = mainCamera.GetComponent<ScreenShake>(); //gets the ScreenShake script component from the camera
        if (!bxCollider)
        {
            bxCollider = GetComponent<BoxCollider2D>(); //reference check to the collider
        }
        DistanceObject = GameObject.Find("Score"); //finds the score text from the canvas
        distanceManagerScript = DistanceObject.GetComponent<DistanceManager>(); //sets the distanceManagerScript to the DistanceManager component of the Score gameobject

    }

    // Update is called once per frame
    void Update()
    {
        if(horseHearts == 4) //display all hearts if health is full
        {
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (horseHearts == 3) //display two hearts if health is at 3
        {
            hearts[2].SetActive(false);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (horseHearts == 2) //display one heart if health is at 2
        {
            hearts[1].SetActive(false);
            hearts[0].SetActive(true);
        }
        else if (horseHearts <= 1 && !isPaused) //otherwise, if health is at or less than one:
        {
            hearts[0].SetActive(false);         //last heart is disabled
            Time.timeScale = 0f;                //game is paused
            isPaused = true;                    //paused bool is true
            TicketTier earned = TicketTier.None;//sets the ticket tier to none by default
            if (distanceManagerScript.count <= 500f && !isDead) //if the score is less than 500 (and you are not dead, but you are at 0 hearts)
            {
                earned = TicketTier.One;        //sets ticket tier in score manager to one
                isDead = true;                  //officially dead
            }
            else if (distanceManagerScript.count >= 501f && distanceManagerScript.count <= 1000f && !isDead) //if score is less than or equal to 1000 and you arent dead (yet)
            {
                earned = TicketTier.Two;        //sets ticket tier in score manager to two
                isDead = true;                  //officially dead part 2

            } 
            else if (distanceManagerScript.count >= 1001f && !isDead) //if score is HIGHER than 1000 and you're not dead (again...yet)
            {
                earned = TicketTier.Three;      //sets ticket tier in score manager to three
                isDead = true;                  //dead as a doornknob
            }
            EventManager.instance.TriggerGameOver(earned); //triggers game over event and changes scenes
        }

      

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle") //if player collides with an obstacle
        {
            horseHearts -= 1;               //lose a heart
            damageSound.Play(0);            //play damage SFX
            screenShake.ShakeScreen();      //screen wobble

        }
        if (collision.tag == "Health Pickup")   //if player collides with a health pickup
        {
            if (horseHearts <= 3)               //only if they're not at full hearts
            {
                horseHearts += 1;               //add one heart
                pickupSound.Play(0);            //plays pick up SFX
            }
        }
    }

    
}
