using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CentipedeBreakout;

public class CBBullet : MonoBehaviour
{
    public float ShotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("PEWPEPWPEW");
        if (collision.gameObject.tag == "Centipede")
        {
            collision.gameObject.GetComponent<Segment>().LoseHealth();
        }
    }
    */

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
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - Vector3.up * 0.75f, Vector2.up * 0.5f);

        if (hit.collider.gameObject.tag == "Centipede")
        {
            CBAudioManager.instance.PlaySound("ShotHit");
            hit.collider.gameObject.GetComponent<Segment>().LoseHealth();
            Destroy(gameObject);
        }




        transform.position += new Vector3(0,ShotSpeed,0);

        if (transform.position.y > 4.3f)
        {
            Destroy(gameObject);
        }
    }
}
