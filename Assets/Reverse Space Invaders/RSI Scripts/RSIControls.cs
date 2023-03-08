using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeAnarchy
{
    public class RSIControls : PlayerScript
    {
        protected override void MoveRight()
        {
            Debug.Log("Right!");
            Vector3 temp = new Vector2(-1f, 0);
        }
        protected override void MoveLeft()
        {
            Debug.Log("Left!");

        }
        protected override void MoveUp()
        {
            Debug.Log("Up!");
        }
        protected override void MoveDown()
        {
            Debug.Log("Down!");
        }
    }
}





