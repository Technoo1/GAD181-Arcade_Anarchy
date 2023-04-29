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

            // TWO PLAYERS
            if (PlayerManager.instance.twoPlayer == true) // If Two players only WASD controls for Aliens.
            { 
                if (Input.GetKey(KeyCode.A))
                {
                    movement.x--;
                    //movement.x = Input.GetAxisRaw("Horizontal");
                    //Debug.Log("I'm still being pressed");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    movement.x++;
                    //movement.x = Input.GetAxisRaw("Horizontal");
                    //Debug.Log("I'm still being pressed");
                }
            }
            
            // SINGLE PLAYER
            else if (PlayerManager.instance.twoPlayer == false) // If single player then WASD controls and arrows for Aliens.
            {
                movement.x = 0f;
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    movement.x--;
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {   
                    movement.x++;
                }
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