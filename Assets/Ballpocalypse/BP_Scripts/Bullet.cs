using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    




    // Start is called before the first frame update
    void Start()
    {
        // Shoots up or left and right
        //if(ShootingHorizontal == true)
        //{
        //    rb.velocity = transform.right * speed;
        //}

        //if(ShootingUp == true)
        //{
        //    rb.velocity = transform.up * speed;
        //}

        rb.velocity = transform.right * speed;
        //rb.velocity = transform.up * speed;
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
