using UnityEngine;
using UnityEngine.UI;

public class BP_Score : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
