using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private bool scoreRunning = false;
    private float timeElapsed = 0.0f;
    private float scoreIncrement = 1.0f;
    void Start()
    {
        StartScoreSystem();
    }


    void Update()
    {
        if (scoreRunning)
        {
            timeElapsed += Time.deltaTime;
            scoreIncrement += timeElapsed * 25f;
            int newScore = Mathf.FloorToInt(scoreIncrement);

            if (newScore != score)
            {
                score = newScore;
                scoreText.text = score.ToString() + "m";
            }
            if (scoreIncrement >= 25f)
            {
                scoreIncrement -= 25f;
            }
        }
    }

    public void StartScoreSystem()
    {
        scoreRunning = true;
    }
}
