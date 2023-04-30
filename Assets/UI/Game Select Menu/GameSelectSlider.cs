using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectSlider : MonoBehaviour
{
    private int gameID;

    public GameObject[] gamesArray;
    void Start()
    {
        gamesArray[gameID].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButtonClick()
    {
        gamesArray[gameID].SetActive(false);
        gameID = (gameID + 1) % gamesArray.Length;
        gamesArray[gameID].SetActive(true);
    }
    public void RightButtonClick()
    {
        gamesArray[gameID].SetActive(false);
        gameID--;
        if(gameID < 0)
        {
            gameID = gamesArray.Length - 1;
        }
        gamesArray[gameID].SetActive(true);
    }
}
