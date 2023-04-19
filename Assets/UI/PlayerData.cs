using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int tickets;
    
    //constructor
    public PlayerData (ScoreManager score)
    {
        tickets = score.Tickets;
    }

    public PlayerData (int score)
    {
        tickets = score;
    }




}
