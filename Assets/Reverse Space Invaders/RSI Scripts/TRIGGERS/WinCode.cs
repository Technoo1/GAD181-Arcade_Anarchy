using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ArcadeAnarchy;

public class WinCode : MonoBehaviour
{
    private bool isDead;
    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.CompareTag("Alien") && !isDead)
        {
            isDead = true;
            TicketTier earned = TicketTier.Two;
            EventManager.instance.TriggerGameOver(earned);
            //SceneManager.LoadScene("MenuScreen");
        }
    }
}
