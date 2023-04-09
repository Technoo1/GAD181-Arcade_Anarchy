using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int tickets;
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
    private void Start()
    {
        ScoreManager.instance.onTicketTierOne += TierOne;
        ScoreManager.instance.onTicketTierTwo += TierTwo;
        ScoreManager.instance.onTicketTierThree += TierThree;

    }
    private void OnDisable()
    {
        ScoreManager.instance.onTicketTierOne -= TierOne;
        ScoreManager.instance.onTicketTierTwo -= TierTwo;
        ScoreManager.instance.onTicketTierThree -= TierThree;
    }

    // Update is called once per frame
    void Update()
    {
        //tickets += ticketsEarned;
        if (Input.GetKeyDown(KeyCode.P))
        {
            tickets += 1;
        }

        ticketText.text = tickets.ToString();

        if (addedTicketScoreText != null)
        {
            addedTicketScoreText.SetText(ticketsEarned.ToString());
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
        tickets = data.tickets;
        ticketText.text = tickets.ToString();
    }

    public void OnEnable()
    {
        //LoadScore();
    }

    // Ticketting Events
    public event Action onTicketTierOne; 
    public event Action onTicketTierTwo;
    public event Action onTicketTierThree;

    public void TicketTierOne() 
    {
        onTicketTierOne?.Invoke();
    }
    public void TicketTierTwo()
    {
        onTicketTierTwo?.Invoke();
    }
    public void TicketTierThree()
    {
        onTicketTierThree?.Invoke();
    }

    public void TierOne() 
    {
        ticketsEarned = 50;
       // Debug.Log("Tickets earned: " + ticketsEarned);
        tickets += ticketsEarned;
        addedTicketScoreText.gameObject.SetActive(true);
        if (addedTicketScoreText != null)
        {
            addedTicketScoreText.text = ticketsEarned.ToString();
            Debug.Log("tickets changed");
        }
        else
        {
            Debug.LogError("Tickets not changed");
        }
    }
    public void TierTwo()
    {
        ticketsEarned = 75;

    }
    public void TierThree()
    {
        ticketsEarned = 100;

    }
}
