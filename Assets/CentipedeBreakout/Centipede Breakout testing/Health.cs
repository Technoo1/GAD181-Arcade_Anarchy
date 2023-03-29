using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CentipedeBreakout;
using System.Xml.Serialization;

namespace CentipedeBreakout
{
    public class Health : MonoBehaviour
    {
        //Add invincibility frames

        //Add hearts in inspector

        
        public int secondsInvincible;
        public List<GameObject> hearts;

        private int heartsLeft = 3;
        private int iFrames;

        public void DamageTaken()
        {
            iFrames += 0;

            if(iFrames > secondsInvincible)
            {
                iFrames = 0;
                return;
            }

            heartsLeft -= 1;

            if (heartsLeft < 0)
            {
                Debug.Log("gameover");
                //do this
            }
            else
            {
                hearts[heartsLeft].SetActive(false);
            }
        }
    }
}