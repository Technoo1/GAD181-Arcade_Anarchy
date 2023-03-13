using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeAnarchy
{
    public class RSIControls : MonoBehaviour
    {
        public float moveSpeed = 5f; // Publically float to determine speed.
        public Rigidbody2D rb; // Calls the rigid body so that the sprite can be effected physically.
        public Animator animator; // Calls Unity's in-built animator to animate the sprite this code is attached to.
        Vector2 movement; // Uses a Vector based movement system. Placeholder, change to rigid body based later

        void Update()
        {
            // Input
            movement.x = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Horizontal", movement.x);

            /* Find a way to make it so that once hits boundary area, pushes alien swarm down a row.
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Vertical", movement.y); */
            animator.SetFloat("Speed", movement.sqrMagnitude);

            // if(rb.position ==  )
            // {

            // }
        }

        void FixedUpdate()
        {
            // Executes movement code: checks where sprite is then uses vector movement based on Deltatime.
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}