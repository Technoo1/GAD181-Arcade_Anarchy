using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    public Projectile laserPrefab; // Reference to the Projectile script 

    public float moveSpeed = 5f; // Public float to determine speed.

    public Rigidbody2D rb; // Calls the rigid body so that the sprite can be effected physically.

    Vector2 movement; // Uses a Vector based movement system. Placeholder, change to rigid body based later

    void Update()
    {
        // Tank Movement code
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

        // Tank Shooting code
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot(); //Instantiates bullets
        }
    }

    private void Shoot() // Code that instantiates and fires a projectile from the tank
    {
        Instantiate(this.laserPrefab, this.transform.position, quaternion.identity);
    }

    void FixedUpdate()
    {
        // Executes movement code: checks where sprite is then uses vector movement based on Deltatime.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}