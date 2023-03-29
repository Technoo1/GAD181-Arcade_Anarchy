using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CentipedeBreakout;
using System.Xml.Serialization;
using ArcadeAnarchy;


    public class Health : MonoBehaviour
    {
        public float secondsInvincible = 0;

        //Add hearts in inspector
        public List<GameObject> hearts;

        private int heartsLeft = 3;
        private float iFrames = 0;


        private void Start()
        {
            if (secondsInvincible <=0)
            {
                secondsInvincible = 1;
            }

            EventManager.instance.OnHeartLost += HeartLost;
        }


        private void Update()
        {
            iFrames += Time.deltaTime;
        }

        public void HeartLost()
        {
            if(iFrames < secondsInvincible)
            {
                return;
            }

            heartsLeft -= 1;

            if (heartsLeft < 0)
            {
                EventManager.instance.TriggerGameOver();
            }
            else
            {
                hearts[heartsLeft].SetActive(false);
                iFrames = 0;
            }
        }
    }
