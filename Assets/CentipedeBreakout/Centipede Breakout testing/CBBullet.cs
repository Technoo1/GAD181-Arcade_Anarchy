using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CentipedeBreakout;

public class CBBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Centipede")
        {
            collision.gameObject.GetComponent<Segment>().LoseHealth();
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Centipede")
        {
            collision.gameObject.GetComponent<Segment>().LoseHealth();
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0.05f,0);

        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
