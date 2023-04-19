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
        if (playerHearts == 3)
        {
            hearts[2].SetActive(false);
        }
        else if (playerHearts == 2)
        {
            hearts[1].SetActive(false);
            StartCoroutine(FlashRedHeart());
        }
        else if (playerHearts <= 1)
        {
            hearts[0].SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
            EventManager.instance.TriggerGameOver();

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
    } 



}
