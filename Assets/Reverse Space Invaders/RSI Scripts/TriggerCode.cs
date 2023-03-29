using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCode : MonoBehaviour
{
    public GameObject OutOfBounds;
    public string side;

    private void OnTriggerEnter2D(Collider2D Object)
    {
        if(Object.name == "Tank") // Checks object name and executes this code if collided
        {
            // Gets the transform (position) of the Tank 
            Vector2 pos = Object.GetComponent<Transform>().position;

            if (side == "Left")
            {
                pos.x += 0.16f; // This pushes tank to the right
            }
            else if (side == "Right")
            {
                pos.x -= 0.16f; // This pushes tank to the left
            }

            Object.GetComponent<Transform>().position = pos;

            /* Test code. Instantiates a sprite to show trigger is working
             * OutOfBounds.GetComponent<SpriteRenderer>().enabled = true; 
             */
        }

       if (Object.name == "Alien")
        {
            Vector2 pos = Object.GetComponent<Transform>().position;
            pos.y -= 1;
            Object.GetComponent<Transform>().position = pos;
            
            if (side == "Left")
            {
                pos.x += 0.16f; // This pushes tank to the right
            }
            else if (side == "Right")
            {
                pos.x -= 0.16f; // This pushes tank to the left
            }
        }
    }

    void Awake()
    {
        /*bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.size = new Vector2(1.3f, 1.3f);
        bc.isTrigger = true;

        rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Kinematic;*/
    }

    void Start()
    {

    }
}