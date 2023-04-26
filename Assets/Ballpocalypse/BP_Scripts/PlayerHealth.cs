using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public int potionRestore = 20;

    public HealthBar healthbar;
    
    public bool isPaused = false;
    public bool isDead = false;

    public SpriteRenderer sprite;

    void RestoreHealth()
    {
        healthbar.SetHealth(currentHealth + potionRestore);
        currentHealth += potionRestore;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Time.timeScale = 0f;
            isPaused = true;
            TicketTier earned = TicketTier.Two; //sets the ticket tier to none by default
            EventManager.instance.TriggerGameOver(earned); //triggers game over event and changes scenes 
            Destroy(gameObject);
        }
    }

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

        void Update()
        {
        
        if (Input.GetKeyDown(KeyCode.P)) // Pauses & Unpauses the game if P is pressed
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
            TakeDamage(25);
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Large Ball")
        {
            TakeDamage(20);
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Medium Ball")
        {
            TakeDamage(15);
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Small Ball")
        {
            TakeDamage(10);
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Smallest Ball")
        {
            TakeDamage(5);
            StartCoroutine(FlashRed());
        }

        if (collision.tag == "Potion")   
        {
            RestoreHealth();
            
        }
    } 



}
