using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Public float to determine speed.
    public Rigidbody2D rb; // Calls the rigid body so that the sprite can be effected physically.
    Vector2 movement; // Uses a Vector based movement system. Placeholder, change to rigid body based later

    void Update()
    {

        // Add a shooting function for the tank here
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }*/

        movement.x = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            Debug.Log("I'm still being pressed");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            Debug.Log("I'm still being pressed");
        }


        /* Find a way to make it so that once hits boundary area, pushes alien swarm down a row.
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", movement.y); */

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