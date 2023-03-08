using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeAnarchy
{
    public class PlayerScript2D : PlayerScript
    {
        protected override void Jump()
        {
            base.Jump();
            Debug.Log("Wahoo!");
        }
    }
}

