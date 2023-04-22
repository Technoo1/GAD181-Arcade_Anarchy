using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHearts = 4;
    public List<GameObject> hearts;
    public bool isPaused = false;

    public bool isDead = false;

    public SpriteRenderer sprite;

    // Makes the character flash red when hit.
    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    public IEnumerator FlashRedHeart()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.01f);
        sprite.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

   

    void Update()
    {
        if (playerHearts == 4)
        {
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (playerHearts == 3)
        {
            hearts[2].SetActive(false);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (playerHearts == 2)
        {
            hearts[1].SetActive(false);
            hearts[0].SetActive(true);
        }
        else if (playerHearts <= 1 && !isDead)
        {
            hearts[0].SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
            TicketTier earned = TicketTier.Two;
            EventManager.instance.TriggerGameOver(earned);
            isDead = true;
            Debug.Log("Loaded gameOver from " + name);
        }

        if (Input.GetKeyDown(KeyCode.P))
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

    // Takes a heart away once Ball has collided with player.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Largest Ball")
        {
            playerHearts -= 1;
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Large Ball")
        {
            playerHearts -= 1;
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Medium Ball")
        {
            playerHearts -= 1;
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Small Ball")
        {
            playerHearts -= 1;
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Smallest Ball")
        {
            playerHearts -= 1;
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Health Pickup")   
        {
            
            if (playerHearts <= 3)               
            {
                playerHearts += 1;                  
            }
        }
    } 



}
