using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ArcadeAnarchy;

namespace ArcadeAnarchy
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager instance;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }

        public event Action<string> OnUpdateUI; //Output, attach a string to the action
        public void UpdateUI(string text) //Input, passing a string to anything listening
        {
            OnUpdateUI?.Invoke(text);
        }

        public event Action<TicketTier> OnTriggerGameOver;
        public void TriggerGameOver(TicketTier tier)
        {
            OnTriggerGameOver?.Invoke(tier);
        }

        public event Action OnHeartLost;

        public void HeartLost()
        {
            OnHeartLost?.Invoke();
        }

    }

}


