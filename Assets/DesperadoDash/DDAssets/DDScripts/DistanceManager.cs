using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    public int count = 0;
    private float timer = 0f;
    private float counterSpeed = 15f;
    public TextMeshProUGUI countText;

    private void Start()
    {
        ScoreEvents.instance.OnThousandMeters += ThousandMeters;
        ScoreEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }

    void FiveHundredMeters()
    {
        counterSpeed = 20f;
    }
    void ThousandMeters()
    {
        counterSpeed = 25f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f / counterSpeed)
        {
            count++;
            countText.text = count.ToString() + "m";
            timer -= 1f / counterSpeed;
        }
    }
}
