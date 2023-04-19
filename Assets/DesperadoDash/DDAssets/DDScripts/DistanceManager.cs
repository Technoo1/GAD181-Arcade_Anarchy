using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    //this script controlls the score/distance counter at the top of the screen in the UI (how far the horse has run)
    public int count = 0;
    private float timer = 0f;
    private float counterSpeed = 15f;
    public TextMeshProUGUI countText;

    private void Start()
    {
        DistanceEvents.instance.OnThousandMeters += ThousandMeters; //subscribe this function to the event Action
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters; //subscribe this function to the event Action
    }

    private void OnDisable()
    {
        DistanceEvents.instance.OnThousandMeters -= ThousandMeters; //unsubscribe this function from the event Action
        DistanceEvents.instance.OnFiveHundredMeters -= FiveHundredMeters; //unsubscribe this function from the event Action
    }

    void FiveHundredMeters() //when the event is invoked, this function is called and makes the speed of the counter faster
    {
        counterSpeed = 20f;
    }
    void ThousandMeters() //when the event is invoked, this function is called and makes the speed of the counter faster
    {
        counterSpeed = 25f;
    }
    void Update()
    {
        timer += Time.deltaTime; //set timer (the float, not text)
        if (timer >= 1f / counterSpeed) //if the timer is less than or equal to 1 divided by the counter speed
        {
            count++; //add to the count (by default this will be 15 a second)
            countText.text = count.ToString() + "m"; //set the counter text to the count float (but make it a string) + meters
            timer -= 1f / counterSpeed; //reset the timer
        }
    }

}
