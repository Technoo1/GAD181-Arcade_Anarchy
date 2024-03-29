using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeAnarchy
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController2D controller;
        public Animator animator;

        public float runSpeed = 40f;

        float horizontalMove = 0f;
        bool jump = false;
        bool crouch = false;

        public AudioSource jumpSource;
        public AudioClip jumping;


         void Update()
         {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
                jumpSource.PlayOneShot(jumping);
            }

            if (Input.GetButton("Crouch"))
            {
                crouch = true;

            } 
            else if(Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }

        }

        public void OnLanding()
        {
            animator.SetBool("IsJumping", false);
        }

        public void OnCrouching (bool isCrouching)
        {
            animator.SetBool("IsCrouching", isCrouching);
        }

        private void FixedUpdate()
        {
            //Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;

        }
    }
}
