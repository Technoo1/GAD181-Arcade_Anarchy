using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeAnarchy
{
    public class PlayerScript : MonoBehaviour
    {
        public void Start()
        {
            InputManager.instance.OnJump += Jump;
            InputManager.instance.OnRight += MoveRight;
            InputManager.instance.OnLeft += MoveLeft;
            InputManager.instance.OnUp += MoveUp;
            InputManager.instance.OnDown += MoveDown;
            //EventManager.instance.UpdateUI("9/10HP");
        }

        protected virtual void Jump()
        {
            Debug.Log("Jump!");
        }
        protected virtual void MoveRight()
        {
            Debug.Log("Right!");
        }
        protected virtual void MoveLeft()
        {
            Debug.Log("Left!");

        }
        protected virtual void MoveUp()
        {
            Debug.Log("Up!");
        }
        protected virtual void MoveDown()
        {
            Debug.Log("Down!");
        }
    }
}





