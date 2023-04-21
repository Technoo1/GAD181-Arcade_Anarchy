using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 20f;

    private void Start() //subs to event
    {
        DistanceEvents.instance.OnThousandMeters += ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }

    private void OnDisable() //unsubs to event when scene is unloaded
    {
        DistanceEvents.instance.OnThousandMeters -= ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters -= FiveHundredMeters;
    }

    void FiveHundredMeters() //sets speed of movement
    {
        moveSpeed = 16.25f;
    }
    void ThousandMeters()   //sets speed of movement
    {
        moveSpeed = 18f;
    }

    
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); //moves obstacle to the left
    }
    public void OnTriggerEnter2D(Collider2D hitInfo) //if it hits the destruction zone, destroy it
    {
        if (hitInfo.tag == "DestroyBorder")
        {
            Destroy(this.gameObject);
        }
    }

}
