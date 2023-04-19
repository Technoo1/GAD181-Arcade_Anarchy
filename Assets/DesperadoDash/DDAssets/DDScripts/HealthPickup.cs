using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private float moveSpeed = 13f;

    private void Start()
    {
        DistanceEvents.instance.OnThousandMeters += ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }
    void FiveHundredMeters()
    {
        moveSpeed = 16.25f;
    }
    void ThousandMeters()
    {
        moveSpeed = 18f;
    }
    private void Update()
    {
        this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    

}
