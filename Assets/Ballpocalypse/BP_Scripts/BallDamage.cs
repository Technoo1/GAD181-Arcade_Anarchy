using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 20;
   

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if(hitinfo.tag == "Player")
        {
           hitinfo.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
