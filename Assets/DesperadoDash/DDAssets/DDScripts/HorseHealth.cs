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

    ScreenShake screenShake;

    void Start()
    {
        screenShake = Camera.main.GetComponent<ScreenShake>();
        if (!bxCollider)
        {
            bxCollider = GetComponent<BoxCollider2D>();
        }

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
