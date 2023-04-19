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
        startPoint = new Vector2(9.72f, 1.03f);
        endPoint = new Vector2(-33f, -6.84f);
        speed = 10f;

        DistanceEvents.instance.OnThousandMeters += ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, endPoint, (speed * Time.deltaTime));
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "DestroyBorder")
        {
            Destroy(this.gameObject);
        }
    }
    
    public void ThousandMeters()
    {
        speed = 15f;
    }

    public void FiveHundredMeters()
    {
        speed = 20f;
    }
}
