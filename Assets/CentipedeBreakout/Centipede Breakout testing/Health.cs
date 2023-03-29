using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CentipedeBreakout;
using System.Xml.Serialization;

namespace CentipedeBreakout
{
    public class Health : MonoBehaviour
    {
        //Add hearts in inspector

        public List<GameObject> hearts;
        private int heartsLeft = 3;

        public void DamageTaken()
        {
            heartsLeft -= 1;

            if (heartsLeft < 0)
            {
                Debug.Log("gameover");
                //Actually do the thing
            }
            else
            {
                hearts[heartsLeft].SetActive(false);
            }
        }
    }
}