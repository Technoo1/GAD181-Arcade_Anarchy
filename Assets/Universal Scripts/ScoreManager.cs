using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int tickets;
    public TextMeshProUGUI ticketText;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            tickets += 1;
        }
        ticketText.text = tickets.ToString();
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
        LoadScore();
    }
}
