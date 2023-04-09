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

    private GameObject DistanceObject;
    private DistanceManager distanceManagerScript;

    public bool isDead = false;
    public bool gameOverLoaded = false;
    void Start()
    {
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
        else if (horseHearts <= 1)
        {
            hearts[0].SetActive(false);
            //Debug.Log("death");
            Time.timeScale = 0f;
            isPaused = true;
            EventManager.instance.TriggerGameOver();
            if (distanceManagerScript.count <= 500f && !isDead)
            {
                ScoreManager.instance.TicketTierOne();
                isDead = true;
                Debug.Log("Ticket Tier one");
            }
            else if (distanceManagerScript.count >= 501f && distanceManagerScript.count <= 1000f && !isDead)
            {
                ScoreManager.instance.TicketTierTwo();
                isDead = true;

            } 
            else if (distanceManagerScript.count >= 1001f && !isDead)
            {
                ScoreManager.instance.TicketTierThree();
                isDead = true;
                
            }
            //EventManager.instance.TriggerGameOver();
            //if (!gameOverLoaded && isDead)
            //{
            //    EventManager.instance.TriggerGameOver();
            //    gameOverLoaded = true;
            //}
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

        }
    }

    
}
