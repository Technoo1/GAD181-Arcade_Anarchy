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

    public Camera mainCamera;
    private ScreenShake screenShake;
    private GameObject DistanceObject;
    private DistanceManager distanceManagerScript;

    public bool isDead = false;
    public bool gameOverLoaded = false;
    void Start()
    {
        screenShake = mainCamera.GetComponent<ScreenShake>();
        if (!bxCollider)
        {
            bxCollider = GetComponent<BoxCollider2D>();
        }
        DistanceObject = GameObject.Find("Score");
        distanceManagerScript = DistanceObject.GetComponent<DistanceManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (horseHearts == 3)
        {
            hearts[2].SetActive(false);
        }
        else if (horseHearts == 2)
        {
            hearts[1].SetActive(false);
        }
        else if (horseHearts <= 1 && !isPaused)
        {
            hearts[0].SetActive(false);
            //Debug.Log("death");
            Time.timeScale = 0f;
            isPaused = true;
            TicketTier earned = TicketTier.None;
            if (distanceManagerScript.count <= 500f && !isDead)
            {
                earned = TicketTier.One;
                isDead = true;
                Debug.Log("Ticket Tier one");
            }
            else if (distanceManagerScript.count >= 501f && distanceManagerScript.count <= 1000f && !isDead)
            {
                earned = TicketTier.Two;
                isDead = true;

            } 
            else if (distanceManagerScript.count >= 1001f && !isDead)
            {
                earned = TicketTier.Three;
                isDead = true;
            }
            EventManager.instance.TriggerGameOver(earned);
        }

      
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            horseHearts -= 1;
            Debug.Log("Hit!");
            damageSound.Play(0);
            screenShake.ShakeScreen();

        }
    }

    
}
