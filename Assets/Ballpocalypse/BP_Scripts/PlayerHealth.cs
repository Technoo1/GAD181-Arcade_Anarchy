using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

   public void TakeDamage(int damage)
    {
        playerHealth = playerHealth -= damage;
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
            EventManager.instance.TriggerGameOver(TicketTier.None); 
        }
   }



}
