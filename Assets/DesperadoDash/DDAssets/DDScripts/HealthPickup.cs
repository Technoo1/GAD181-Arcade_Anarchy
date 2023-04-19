using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private float moveSpeed = 13f;

    private void Start() //subscribes these functions to the distance event
    {
        DistanceEvents.instance.OnThousandMeters += ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }
    private void OnDisable() //unsubscribes these functions to the distance event when the scene is unloaded
    {
        DistanceEvents.instance.OnThousandMeters -= ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters -= FiveHundredMeters;
    }
    void FiveHundredMeters() //when the event is invoked the health pickup moves faster
    {
        moveSpeed = 16.25f;
    }
    void ThousandMeters()//when the event is invoked the health pickup moves faster
    {
        moveSpeed = 18f;
    }
    private void Update()
    {
        this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); //every frame the game object will move to the left at a speed (smoothened by Time.deltaTime)
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //if the gameobject hits something with the tag "Player" aka, the horse, it will be destroyed.
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "DestroyBorder") //if the gameobject hits the destruction border, it gets destroyed.
        {
            Destroy(this.gameObject);
        }
    }

    

}
