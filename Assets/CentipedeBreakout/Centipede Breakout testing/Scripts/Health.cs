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

    public int heartsLeft = 3;
    private float iFrames = 0;

    public GameObject player;

    private void Start()
    {
        heartsLeft = 3;
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
        if (iFrames < secondsInvincible)
        {
            return;
        }

        heartsLeft -= 1;

        if (heartsLeft < 0)
        {
            Debug.Log("Why in fuck Am I triggering");
            PointScorer.instance.CBGameOver();
            //EventManager.instance.TriggerGameOver(earned);
        }
        else
        {
            hearts[heartsLeft].SetActive(false);
            iFrames = 0;
        }
    }

    public void OnDisable()
    {
        EventManager.instance.OnHeartLost -= HeartLost;
    }

}
