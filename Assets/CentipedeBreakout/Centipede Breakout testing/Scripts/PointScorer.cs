using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointScorer : MonoBehaviour
{
    //Ensures event can be accessed
    public static PointScorer instance;

    //TMPRO decleration
    private TextMeshProUGUI Text;

    public int totalPoints;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public event Action<int> OnPointGain;
    public void PointGain(int PointGain)
    {
        OnPointGain?.Invoke(PointGain);

        //EUUUGh
        Debug.Log("Popopi");
        totalPoints += PointGain;
        Text.text = totalPoints.ToString();
    }

    private void Start()
    {
        Text = gameObject.GetComponent<TextMeshProUGUI>();

    }

    /*
    private void Update()
    {
        Text.text = totalPoints.ToString();
    }
    */
}
