using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private float forceX;
    private float forceY;
    private Vector3 temp;

    private Rigidbody2D myBody;

    [SerializeField]
    private bool moveLeft, moveRight;

    [SerializeField]
    private GameObject originalBall;

    private GameObject ball1, ball2;
    private BallScript ball1Script, ball2Script;

    [SerializeField]
    private AudioClip[] popSounds;

    // Start is called before the first frame update
    private void Awake()
    {
        SetBallSpeed();
        myBody = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        MoveBall();
    }

    void InstantiateBalls()
    {
        if(this.gameObject.tag != "Smallest Ball")
        {
            ball1 = Instantiate(originalBall); 
            ball2 = Instantiate(originalBall);

            ball1.name = originalBall.name;
            ball2.name = originalBall.name;

            ball1Script = ball1.GetComponent<BallScript>();
            ball2Script = ball2.GetComponent<BallScript>();
        }
    }

    void InitializeBallsAndTurnOffCurrentBall()
    {
        InstantiateBalls();

        Vector3 temp = transform.position;

        ball1.transform.position = temp;
        ball1Script.SetMoveLeft(true);

        ball2.transform.position = temp;
        ball2Script.SetMoveRight(true);

        ball1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2.5f);
        ball1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2.5f);

        Random.Range(4, 10);

        gameObject.SetActive(false);
    }



    public void SetMoveLeft(bool canMoveLeft)
    {
        this.moveLeft = canMoveLeft;
        this.moveRight = !canMoveLeft;
    }   
    
    public void SetMoveRight(bool canMoveRight)
    {
        this.moveRight = canMoveRight;
        this.moveLeft = !canMoveRight;
    }


    void MoveBall()
    {
        if (moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x -= +forceX * Time.deltaTime;
            transform.position = temp;
        }

        if (moveRight)
        {
            Vector3 temp = transform.position;
            temp.x += +forceX * Time.deltaTime;
            transform.position = temp;
        }
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

        if(target.tag == "Right Wall")
        {
            SetMoveLeft(true);
        }

        if(target.tag == "Left Wall")
        {
            SetMoveRight(true);
        }

        if(target.tag == "Bullet")
        {
            if(gameObject.tag != "Smallest Ball")
            {
                InitializeBallsAndTurnOffCurrentBall();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

    }
}
