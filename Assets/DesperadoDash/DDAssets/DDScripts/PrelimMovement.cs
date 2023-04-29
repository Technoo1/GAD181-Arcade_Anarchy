using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrelimMovement : MonoBehaviour
{

    private BoxCollider2D bxCollider2d;
    public float baseSpeed;
    private Vector3 moveDirection;

    public List<Transform> Lanes;
    public int currentLane = 1;

    public Animator anim;
    public bool IsJump = false;
    public float jumpAmmount;

    private bool isAtLeftEdge, isAtRightEdge;
    public GameObject boundary;


    // Start is called before the first frame update
    void Start()
    {

        if (!bxCollider2d)
        {
            bxCollider2d = GetComponent<BoxCollider2D>();
        }

        anim = gameObject.GetComponent<Animator>();

        InputManager.instance.OnLeft += MoveLeft; //sub to input manager
        InputManager.instance.OnRight += MoveRight;
        InputManager.instance.OnJump += Jump;

    }

    private void OnDisable() //unsub from input manager when scene is unloaded
    {
        InputManager.instance.OnLeft -= MoveLeft;
        InputManager.instance.OnRight -= MoveRight;
        InputManager.instance.OnJump -= Jump;
    }

    public void MoveRight() //smoothly moves player to the right
    {
        if (transform.position.x <= 7f)
        {
            moveDirection = transform.right;
            transform.position += moveDirection * (baseSpeed * Time.deltaTime);
        }

    }
    public void MoveLeft() //smoothly moves player to the left
    {
        if (transform.position.x >= -7f )
        {
            moveDirection = -transform.right;
            transform.position += moveDirection * (baseSpeed * Time.deltaTime);
        }
    }

    

    public void Jump() //only jump when not already jumping
    {
        if (IsJump)
        {
            //Debug.Log("No Jump");
            return;
        }
        else
        {
            StartCoroutine(WaitForJump());
        }
    }

    public IEnumerator WaitForJump()
    {
        bxCollider2d.enabled = false;                                       //disables collider
        Vector2 startPos = transform.position;                              //stores current Y position
        transform.position = new Vector2(startPos.x, startPos.y + 0.7f);    //moves horse 0.7f upwards
        IsJump = true;                                                      //sets jump to true
        anim.Play("HorseJump");                                             //plays jump animation
        yield return new WaitForSeconds(0.5f);                              //waits half a second
        transform.position = new Vector2(transform.position.x, startPos.y); //moves horse back to the Y position of the startPos
        IsJump = false;                                                     //no longer jumping
        yield return new WaitForSeconds(0.5f);                              //invincibility half a second
        bxCollider2d.enabled = true;                                        //reenables the collider
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !IsJump)                                     //only move up if you're not jumping
        {
            if (currentLane != 0)                                                       //if youre not in the top lane
            {
                currentLane--;                                                          //move up one lane (sets variable)
                Vector2 lane = Lanes[currentLane].position;                             //new vector2 which stores the y position of the current lane
                this.transform.position = new Vector2(transform.position.x, lane.y);    //moves to the y position of current lane, but remains your X position
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && !IsJump)                                     //only move down if youre not jumping
        {
            if (currentLane < Lanes.Count - 1)                                          //only if youre not in the bottom lane
            {
                currentLane++;                                                          //move down one line (sets variable)
                Vector2 lane = Lanes[currentLane].position;                             //new vector2 which stores the y position of the current lane
                this.transform.position = new Vector2(transform.position.x, lane.y);    //moves to the y position of current lane, but remains your X position
            }
        }
    }
    
}
