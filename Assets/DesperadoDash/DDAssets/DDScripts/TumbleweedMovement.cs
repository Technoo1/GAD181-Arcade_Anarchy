using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedMovement : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    private float speed;

    void Start()
    {
        startPoint = new Vector2(9.72f, 1.03f); //start position of the tumbleweed
        endPoint = new Vector2(-33f, -6.84f);   //end position of the tumbleweed
        speed = 10f;                            //speed of tumbleweed

        DistanceEvents.instance.OnThousandMeters += ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }

    private void OnDisable()
    {
        DistanceEvents.instance.OnThousandMeters -= ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters -= FiveHundredMeters;
    }
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, endPoint, (speed * Time.deltaTime)); //moves from start position to the end position, at a smooth speed
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "DestroyBorder") //if it hits a destroy border, then destroy it
        {
            Destroy(this.gameObject);
        }
    }
    
    public void ThousandMeters() //goes faster
    {
        speed = 15f;
    }

    public void FiveHundredMeters()  //goes even faster
    {
        speed = 20f;
    }
}
