using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 20f;

    private void Start()
    {
        ScoreEvents.instance.OnThousandMeters += ThousandMeters;
        ScoreEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }

    void FiveHundredMeters()
    {
        moveSpeed = 16f;
    }
    void ThousandMeters()
    {
        moveSpeed = 19f;
    }

    
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "DestroyBorder")
        {
            Destroy(this.gameObject);
        }
    }
}
