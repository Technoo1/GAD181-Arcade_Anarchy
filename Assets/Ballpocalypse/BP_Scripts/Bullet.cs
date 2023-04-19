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
    private Vector3 mousePos;
    private Camera mainCam;

    public AudioSource bulletSource;

    public AudioSource ballPop;
    public AudioClip popClip;




    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

      
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Destroy(gameObject);

        if (hitInfo.tag == "Largest Ball")
        {
            ballPop.PlayOneShot(popClip);
            Debug.Log("ball popped");
        }

        if (hitInfo.tag == "Large Ball")
        {
            ballPop.PlayOneShot(popClip);
            Debug.Log("ball popped");

        }
        if (hitInfo.tag == "Medium Ball")
        {
            ballPop.PlayOneShot(popClip);
            Debug.Log("ball popped");
        }

        if (hitInfo.tag == "Small Ball")
        {
            ballPop.PlayOneShot(popClip);
            Debug.Log("ball popped");
        }

        if (hitInfo.tag == "Smallest Ball")
        {
            ballPop.PlayOneShot(popClip); 
            Debug.Log("ball popped");
        }
    }
}
