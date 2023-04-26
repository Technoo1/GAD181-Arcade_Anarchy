using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DistanceEvents : MonoBehaviour
{
    public static DistanceEvents instance; //static so it can be called from anywhere

    public DistanceManager scoreManager;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null) //if theres no instance, set this to the instance
        {
            instance = this;
        }
    }

    public event Action OnThousandMeters; 
    public event Action OnFiveHundredMeters;
    public event Action OnTwoThousandMeters;
    // Update is called once per frame
    private void Update()
    {
            if (scoreManager.count >= 500f) //if the score/distance is more than or equal to 500 meters
        {
            OnFiveHundredMeters?.Invoke(); //invoke the event and convey this to all of the listeners to the event
        }
            if (scoreManager.count >= 1000f) //if the score/distance is more than or equal to 1000 meters
        {
            OnThousandMeters?.Invoke(); //invoke the event and convey this to all of the listeners to the event
        }
            if (scoreManager.count >= 2000f)
        {
            OnTwoThousandMeters?.Invoke();
        }

    }
}
