using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum TicketTier { None, One, Two, Three }
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int Tickets { get { return SaveSystem.currentTickets; } set { SaveSystem.currentTickets = value; } }
    public int ticketsEarned;
    public TextMeshProUGUI ticketText;
    public TextMeshProUGUI addedTicketScoreText;


    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //tickets += ticketsEarned;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Tickets += 1;
        }

        ticketText.text = Tickets.ToString();

    }

    public void SaveScore()
    {
        Debug.Log("Saving score...");
        SaveSystem.SaveTickets(this);
    }

    public void LoadScore()
    {
        Debug.Log("loading score...");
        PlayerData data = SaveSystem.LoadTickets();
        ticketText.SetText(Tickets.ToString());
    }

    public void OnEnable()
    {
        LoadScore();
    }

    public void TriggerTicketTier(TicketTier tier)
    {
        switch (tier)
        {
            case TicketTier.None:
                break;
            case TicketTier.One:
                TierOne();
                break;
            case TicketTier.Two:
                TierTwo();
                break;
            case TicketTier.Three:
                TierThree();
                break;
        }
    }

    private void TierOne() 
    {
        Debug.Log("Recieved Command");
        ticketsEarned = 50;
        Tickets += ticketsEarned;
        addedTicketScoreText.gameObject.SetActive(true);
        if (addedTicketScoreText != null)
        {
            addedTicketScoreText.SetText(ticketsEarned.ToString());
            //addedTicketScoreText.text = ticketsEarned.ToString();
            Debug.Log("tickets changed: " + Tickets + " save game tickets: " + SaveSystem.currentTickets);
        }
        else
        {
            Debug.LogError("Tickets not changed");
        }
    }
    private void TierTwo()
    {
        ticketsEarned = 75;

    }
    private void TierThree()
    {
        ticketsEarned = 100;

    }
}
