using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    public Projectile laserPrefab; // Reference to the Projectile script

    public float moveSpeed = 5f; // Public float to determine speed.

    public Rigidbody2D rb; // Calls the rigid body so that the sprite can be effected physically.

    private bool _laserActive;

    public AudioSource bulletSource;
    public AudioClip shotSound;

    Vector2 movement; // Uses a Vector based movement system. Placeholder, change to rigid body based later

    void Update()
    {
        if (PlayerManager.instance.twoPlayer == true)
        { 
            // Tank Movement code
            movement.x = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x = Input.GetAxisRaw("Horizontal");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movement.x = Input.GetAxisRaw("Horizontal");
            }

            // Tank Shooting code
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Shoot(); //Instantiates bullets
                bulletSource = GetComponent<AudioSource>();
                bulletSource.PlayOneShot(shotSound);
            }
        }
        else
        {
            //Do nothing
        }
    }

    private void Shoot() // Code that instantiates and fires a projectile from the tank
    {
        if (PlayerManager.instance.twoPlayer == true)
        {
            if (!_laserActive) //Sets up so that only one bullet can be fired at a time.
            {
                Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, quaternion.identity);
                projectile.destroyed += LaserDestroyed;
                _laserActive = true;
            }
        }
        else
        {
            //Do nothing
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    void FixedUpdate()
    {
        // Executes movement code: checks where sprite is then uses vector movement based on Deltatime.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        bulletSource.Play(); 
    }
}