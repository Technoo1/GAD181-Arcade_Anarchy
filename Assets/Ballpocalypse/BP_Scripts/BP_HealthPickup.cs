using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;
    public List<GameObject> hearts;
    public int playerHearts = 4;

    public float healthBonus = 4;

     void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HealthPickup") 
        {
           
            if (playerHearts <= 3)               //only if they're not at full hearts
            {
                playerHearts += 1;               //add one heart      
            }
        }

    }
}
