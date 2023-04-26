using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ArcadeAnarchy;
using CentipedeBreakout;

public class PointScorer : MonoBehaviour
{
    //Ensures event can be accessed
    public static PointScorer instance;

    //TMPRO decleration
    private TextMeshProUGUI Text;

    public int totalPoints;

    public GameObject player;

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

    public event Action CBOnGameOver;
    public void CBGameOver()
    {
        //CBOnGameOver?.Invoke();

        StartCoroutine(CBGameOverDelay());
    }

    public IEnumerator CBGameOverDelay()
    {
        CBAudioManager.instance.PlaySound("Bloop");
        player.GetComponent<PlayerCentipede>().canMove = false;
        Debug.Log(player.GetComponent<PlayerCentipede>().canMove);
        yield return new WaitForSeconds(2f);
        player.GetComponent<PlayerCentipede>().canMove = true;

        if (totalPoints <= 4000)
        {
            EventManager.instance.TriggerGameOver(TicketTier.None);
        }
        else if (totalPoints <= 4300)
        {
            EventManager.instance.TriggerGameOver(TicketTier.One);
        }
        else if (totalPoints <= 4900)
        {
            EventManager.instance.TriggerGameOver(TicketTier.Two);
        }
        else if (totalPoints >= 5500)
        {
            EventManager.instance.TriggerGameOver(TicketTier.Three);
        }
    }

    private void Start()
    {
        Text = gameObject.GetComponent<TextMeshProUGUI>();
        EventManager.instance.OnTriggerGameOver += TriggerGameOver;
    }

    public void TriggerGameOver(TicketTier tier)
    {

    }

    /*
    private void Update()
    {
        Text.text = totalPoints.ToString();
    }
    */
}
