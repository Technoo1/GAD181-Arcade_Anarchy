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
    
    // Start is called before the first frame update
    void Start()
    {

        if (!bxCollider2d)
        {
            bxCollider2d = GetComponent<BoxCollider2D>();
        }

        anim = gameObject.GetComponent<Animator>();

        InputManager.instance.OnLeft += MoveLeft;
        InputManager.instance.OnRight += MoveRight;
        InputManager.instance.OnJump += Jump;
    }

    public void MoveRight()
    {
        moveDirection = transform.right;
        transform.position += moveDirection * (baseSpeed * Time.deltaTime);
    }
    public void MoveLeft()
    {
        moveDirection = -transform.right;
        transform.position += moveDirection * (baseSpeed * Time.deltaTime);
    }

    public void Jump()
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
        bxCollider2d.enabled = false;
        Vector2 startPos = transform.position;
        transform.position = new Vector2(startPos.x, startPos.y + 0.7f);
        IsJump = true;
        anim.Play("HorseJump");
        //Debug.Log("Jumping!!");
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector2(transform.position.x, startPos.y);
        //transform.position = startPos;
        //yield return new WaitForSeconds(0.3f);
        IsJump = false;
        bxCollider2d.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentLane != 0)
            {
                currentLane--;
                Vector2 lane = Lanes[currentLane].position;
                this.transform.position = new Vector2(transform.position.x, lane.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentLane < Lanes.Count - 1)
            {
                currentLane++;
                Vector2 lane = Lanes[currentLane].position;
                this.transform.position = new Vector2(transform.position.x, lane.y);
            }
        }
    }
}
