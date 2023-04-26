using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public enum TicketTier { None, One, Two, Three }
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int Tickets { get { return SaveSystem.currentTickets; } set { SaveSystem.currentTickets = value; } }
    public int ticketsEarned;
    public TextMeshProUGUI ticketText;
    public TextMeshProUGUI addedTicketScoreText;
    public GameObject menuButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnDisable()
    {
        Debug.Log("Saving score...");
        SaveSystem.SaveTickets(this);
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

        

        if (SaveSystem.loadedScene == "GameOver")
        {
            addedTicketScoreText.gameObject.SetActive(true);
            menuButton.SetActive(true);
        }
        else
        {
            addedTicketScoreText.gameObject.SetActive(false);
            menuButton.SetActive(false);
        }
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
                TierNone();
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

    private void TierNone()
    {
        ticketsEarned = 0;
        Tickets += ticketsEarned;
        addedTicketScoreText.SetText(ticketsEarned.ToString());
        Debug.Log("tickets changed: " + Tickets + " save game tickets: " + SaveSystem.currentTickets);
    }
    private void TierOne() 
    {
        ticketsEarned = 5;
        Tickets += ticketsEarned;
        addedTicketScoreText.SetText(ticketsEarned.ToString());
        Debug.Log("tickets changed: " + Tickets + " save game tickets: " + SaveSystem.currentTickets);
    }
    private void TierTwo()
    {
        ticketsEarned = 10;
        Tickets += ticketsEarned;
        addedTicketScoreText.SetText(ticketsEarned.ToString());
        Debug.Log("tickets changed: " + Tickets + " save game tickets: " + SaveSystem.currentTickets);
    }
    private void TierThree()
    {
        ticketsEarned = 25;
        Tickets += ticketsEarned;
        addedTicketScoreText.SetText(ticketsEarned.ToString());
        Debug.Log("tickets changed: " + Tickets + " save game tickets: " + SaveSystem.currentTickets);
    }
}
