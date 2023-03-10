using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrelimMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D bxCollider2d;
    public float baseSpeed;
    public float lerpSpeed;
    private Vector3 moveDirection;
    private Vector3 upAndDown;
    public float verticalDistance;

    public bool laneOne, laneTwo, laneThree = false;
 

    public BoxCollider2D laneOnebx, LaneTwobx, LaneThreebx;
    // Start is called before the first frame update
    void Start()
    {
        if (!rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (!bxCollider2d)
        {
            bxCollider2d = GetComponent<BoxCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -transform.right;
            transform.position += moveDirection * (baseSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = transform.right;
            transform.position += moveDirection * (baseSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (laneOne)
            {
                transform.position = transform.position;
            }
            else if (!laneOne)
            {
                upAndDown = transform.up;
                transform.position += upAndDown * verticalDistance;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (laneThree)
            {
                transform.position = transform.position;
            }
            else if (!laneThree)
            {
                upAndDown = transform.up;
                transform.position -= upAndDown * verticalDistance;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("laneOne"))
        {
            laneOne = true;
        }
        else if (collision.collider.CompareTag("laneTwo"))
        {
            laneTwo = true;
        }
        else if (collision.collider.CompareTag("laneThree"))
        {
            laneThree = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("laneOne"))
        {
            laneOne = false;
        }
        else if (collision.collider.CompareTag("laneTwo"))
        {
            laneTwo = false;
        }
        else if (collision.collider.CompareTag("laneThree"))
        {
            laneThree = false;
        }
    }
}
