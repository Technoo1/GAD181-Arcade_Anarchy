using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreEvents : MonoBehaviour
{
    public static ScoreEvents instance;

    public DistanceManager scoreManager;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public event Action OnThousandMeters;
    public event Action OnFiveHundredMeters;
    // Update is called once per frame
    private void Update()
    {
            if (scoreManager.count >= 500f)
        {
            OnFiveHundredMeters?.Invoke();
        }
            if (scoreManager.count >= 1000f)
        {
            OnThousandMeters?.Invoke();
        }

    }
}
