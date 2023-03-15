using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private float forceX;
    private float forceY;

    private Rigidbody2D myBody;

    [SerializeField]
    private bool moveLeft, moveRight;

    [SerializeField]
    private GameObject originalBall;

    private GameObject ball1, ball2;
    private BallScript ballScript, ball2Script;

    [SerializeField]
    private AudioClip[] popSounds;

    // Start is called before the first frame update
    private void Awake()
    {
        SetBallSpeed();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBallSpeed()
    {
        forceX = 2.5f;

        switch(this.gameObject.tag)
        {
            case "Largest Ball":
                forceY = 8.5f;
                break;

            case "Large Ball":
                forceY = 7.5f;
                break;

            case "Medium Ball":
                forceY = 6.5f;
                break;

            case "Small Ball":
                forceY = 5f;
                break;

            case "Smallest Ball":
                forceY = 4f;
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Ground")
        {
            myBody.velocity = new Vector2(0, forceY);
        }

    }
}
