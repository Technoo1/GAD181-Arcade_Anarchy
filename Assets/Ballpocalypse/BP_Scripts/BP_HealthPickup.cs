using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_HealthPickup : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //if the gameobject hits something with the tag "Player" aka, the horse, it will be destroyed.
        {
            Destroy(this.gameObject);
        }
    }
}
