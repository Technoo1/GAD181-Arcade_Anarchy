using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeAnarchy
{
    public class PlayerScript1 : MonoBehaviour
    {
        public float moveSpeed = 5f; // Public float to determine speed.
        Vector2 movement; 

        void Update()
        {
            movement.x = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                //Debug.Log("I'm still being pressed");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                //Debug.Log("I'm still being pressed");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement.y = Input.GetAxisRaw("Vertical");
                //Debug.Log("I'm still being pressed");
            }
        }

        void FixedUpdate()
        {
            // Executes movement code: checks where sprite is then uses vector movement based on Deltatime.
            Vector2 pos = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime; ;
            transform.position = pos;
        }
    }
}