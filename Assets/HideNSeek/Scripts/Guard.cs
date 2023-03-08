using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour

//one guard looking left/right sprite to spawn on camera at 5 seconds after game start
//guard checks against 50% chance to swap sprite at 1 second
//if check is successful, swap to alerted/turning sprite (this will be an identical sprite with an added visual cue i.e. exclamation point hanging overhead), after 1 second, swap to front facing guard sprite
//if check is UNsuccessful, do nothing, wait 2 seconds before checking again
//guard can "detect" peeking player in front facing state, trigger microgame game over screen if this happens
//iterate additional check to move left or right at some point
{
    // Update is called once per frame
    void Update()
    {

    }
}
