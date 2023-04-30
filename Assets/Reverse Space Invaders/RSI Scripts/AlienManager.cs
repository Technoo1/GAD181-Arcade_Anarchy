using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienManager : MonoBehaviour
{
    public static AlienManager instance;
    public AnimationHandler[] prefabs; // Array of aliens
    public int rows = 3; // Amount of rows.
    public int columns = 9; // Amount of columns.
    public int deadAliens; // Stores amount of dead aliens as an int.
    private bool isDead; // Bool to stop game over screen from contstantly spawning.
    public int amountkilled {get; private set;}
    public int totalAliens => this.rows * this.columns;
    private Vector3 _direction = Vector2.right;

    private void Awake() 
    {
        instance = this;

        // FOR loops to instantiate the aliens
        for(int row = 0; row < this.rows; row++)
        {
            // Code to offset/center the alien swarm on screen
            float width = 2.2f * (this.columns - 1);
            float height = -1.7f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);            
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            
            for(int col = 0; col < this.columns; col++)
            {
                AnimationHandler Aliens = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                Aliens.transform.localPosition = position;
            }
        }
    }

    private void Update() 
    {   
        // Something to do with camera? Possibly to center camera on aliens? 
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform Aliens in this.transform)
        {
            if(!Aliens.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && Aliens.position.x == rightEdge.x - 1.0f)
            {
                AdvanceRow();         
            } 
            else if (_direction == Vector3.left && Aliens.position.x == leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
            if (_direction == Vector3.right && Aliens.position.x > rightEdge.x - 1.0f)
            {
                AdvanceRow();
            }
            else if (_direction == Vector3.left && Aliens.position.x > leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
        }
        if (deadAliens >= totalAliens && !isDead) // Goes to Game over screen if all aliens are dead.
        {
            isDead = true;
            TicketTier earned = TicketTier.None;
            EventManager.instance.TriggerGameOver(earned);
        }
    }

    private void AdvanceRow() // Moves the alien swarm down a row when called.
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
    }

    private void alienKilled() // Adds dead aliens to list of dead aliens. Not sure if works.
    {
        this.amountkilled ++;
    }
}