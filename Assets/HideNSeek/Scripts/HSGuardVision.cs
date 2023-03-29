using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//DONE guard performs a check after x seconds DONE
//DONE check is 50% chance to swap to another sprite DONE
//DONE if check is successful, swap to alerted/turning guard sprite (this will be an otherwise identical sprite with an added visual cue i.e. exclamation point hanging overhead)
//DONE wait x seconds before swapping again to a front-facing guard sprite
//DONE wait x seconds before swapping back to original sprite
//DONE start first check again
//DONE if check is UNsuccessful, do nothing
//DONE wait x seconds before checking again

//iterate additional check to move left or right, if initial front swap fails

public class HSGuardVision : MonoBehaviour
{
    public float waitForCheck = 1f; //guard performs a check after x second/s
    public float waitTillTurn = 1.5f; //guard waits to fully turn to face player
    public float waitBeforeSwapBack = 3f; //wait x seconds before swapping back to original sprite
    public int guardTurnChance; //probability of guard turning
    //public int guardMoveChance; //probability of guard moving if it doesn't turn
    public Sprite guardTurn; //sprite of all turning guards
    public Sprite guardFront; //sprite of all guards facing forward
    public Sprite guardProfile; //sprite of all guards looking away, default state

    void Start()
    {
        StartCoroutine(StartPatrol());
    }

    IEnumerator StartPatrol()
    {
        yield return new WaitForSeconds(waitForCheck); //waits before executing further
        {
            for (int i = 0; i < 100000000; i++) //loops the coroutine for a gajillion amount of seconds
            {
                guardTurnChance = Random.Range(0, 101); //50% chance of turning
                if (guardTurnChance >= 50)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = guardTurn; //swap to turning sprite
                    print("guard is turning!");
                    yield return new WaitForSeconds(waitTillTurn); //wait before swapping again
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = guardFront; //swap to front-facing sprite
                        transform.tag = "GuardFront";
                        print("guard is facing you!!");
                        yield return new WaitForSeconds(waitBeforeSwapBack); //wait before swapping again
                        {
                            this.gameObject.GetComponent<SpriteRenderer>().sprite = guardProfile; //swap to profile sprite
                            transform.tag = "GuardProfile";
                            print("guard has turned away");
                            yield return new WaitForSeconds(5f); //wait 5 seconds before looping
                        }
                    }
                }
                /*else if (guardTurnChance < 50) //this adds the chance to move left or right after a failed turn check
                {
                    guardMoveChance = Random.Range(0, 101);
                    if (guardMoveChance >= 50)
                    {
                        //swap to another sprite in the sprite renderer component
                        print("guard is moving!");
                    }*/
                else
                {
                    print("guard did nothing...");
                    yield return new WaitForSeconds(5f); //wait 5 seconds before looping
                }
            }
            yield return null;
        }
    }
}