using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_HealthPickup : MonoBehaviour
{

    public HealthBar healthbar;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //if the gameobject hits something with the tag "Player" 
        {
            Destroy(this.gameObject);
            
        }

        if (collision.tag == "Bullet")
        {
            Destroy(this.gameObject);

        }
    }
}
