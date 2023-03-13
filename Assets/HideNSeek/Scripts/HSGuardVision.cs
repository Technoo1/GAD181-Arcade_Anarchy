using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//guard performs a check after 1 second
//check is 50% chance to swap to another sprite
//if check is successful, swap to alerted/turning guard sprite (this will be an otherwise identical sprite with an added visual cue i.e. exclamation point hanging overhead)
//wait 1 second before swapping again to a front-facing guard sprite
//wait 3 seconds before swapping back to original sprite
//start first check again
//if check is UNsuccessful, do nothing
//wait 2 seconds before checking again

//if front-facing guard sprite AND a peeking player sprite are both in the scene, trigger a game over event

//iterate additional check to move left or right, if initial front swap fails

public class HSGuardVision : MonoBehaviour
{
    public float waitForCheck = 1f; //guard performs a check after x second/s
    public float waitTillTurn = 1.5f; //guard waits to fully turn to face player
    public float waitBeforeSwapBack = 3f; //wait x seconds before swapping back to original sprite
    public int guardTurnChance; //probability of guard turning
    //public int guardMoveChance; //probability of guard moving if it doesn't turn
    public Sprite guardTurn;
    public Sprite guardFront;
    public Sprite guardProfile;


    void Start()
    {
        StartCoroutine(StartPatrol());
    }

    IEnumerator StartPatrol()
    {
        yield return new WaitForSeconds(waitForCheck);
        {
            for (int i = 0; i < 100000000; i++)
            {
                guardTurnChance = Random.Range(0, 101);
                if (guardTurnChance >= 50)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = guardTurn;
                    print("guard is turning!");
                    yield return new WaitForSeconds(waitTillTurn);
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = guardFront;
                        print("guard is facing you!!");
                        yield return new WaitForSeconds(waitBeforeSwapBack);
                        {
                            this.gameObject.GetComponent<SpriteRenderer>().sprite = guardProfile;
                            print("guard has turned away");
                            yield return new WaitForSeconds(5f);
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
                    yield return new WaitForSeconds(5f);
                }
            }
            yield return null;
        }
    }
}