using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    // TWO PLAYER VARIABLES
    public Projectile laserPrefab; // Reference to the Projectile script
    public float moveSpeed = 5f; // Public float to determine speed.
    public Rigidbody2D rb; // Calls the rigid body so that the sprite can be effected physically.
    private bool _laserActive;
    Vector2 movement; // Uses a Vector based movement system. Placeholder, change to rigid body based later

    // SOUNDS
    public AudioSource bulletSource;
    public AudioClip shotSound;

    // SINGLE PLAYER VARIABLES
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;

    void Update()
    {
        // TWO PLAYERS
        if (PlayerManager.instance.twoPlayer == true) // If Two player selected then player can control tank.
        { 
            // Tank Movement code
            movement.x = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x--;
                //movement.x = Input.GetAxisRaw("Horizontal");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movement.x++;
                //movement.x = Input.GetAxisRaw("Horizontal");
            }

            // Tank Shooting code
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Shoot(); //Instantiates bullets
            }
        }
        // SINGLE PLAYER
        else if (PlayerManager.instance.twoPlayer == false) // If One player selected then ai controls tank.
        {
            RandomMoveGoToPoint();

            timer += Time.deltaTime;

            if (timer > 0.3f)
            {
                timer = 0;
                Shoot();
            }
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
                bulletSource = GetComponent<AudioSource>(); // Gets the audio source (Tank)
                bulletSource.PlayOneShot(shotSound); // Plays the Pew Pew sound effect.
            }
        }
        else if (PlayerManager.instance.twoPlayer == false)
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
            bulletSource = GetComponent<AudioSource>(); // Gets the audio source (Tank)
            bulletSource.PlayOneShot(shotSound); // Plays the Pew Pew sound effect.
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

    public Transform[] goToRandPoints;
    private int destPoint = 0;

    public float singleSpeed;

    void RandomMoveGoToPoint()
    {
        // Set the agent to go to the currently selected destination.
        transform.position = Vector3.Lerp(transform.position, goToRandPoints[destPoint].position, singleSpeed * Time.deltaTime);

        float remainingDistance = Vector3.Distance(goToRandPoints[destPoint].position, transform.position);

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (goToRandPoints.Length == 0)
            return;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        //destPoint = (destPoint + 1) % points.Length;
        destPoint = UnityEngine.Random.Range(1, goToRandPoints.Length);
    }
}