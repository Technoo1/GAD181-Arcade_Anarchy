using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.PlayerSettings;

public enum Side { Left, Right }

public class TriggerCode : MonoBehaviour
{
    public YTransfromer yTransformer;
    public GameObject OutOfBounds;
    public Side side;
    //Bools to activate and deactivate the triggers. Makes aliens go to opposite of screen each time to go down.

    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.name == "Tank") // Checks object name and executes this code if collided
        {
            // Gets the transform (position) of the Tank 
            Vector2 pos = Object.GetComponent<Transform>().position;

            if (side == Side.Left)
            {
                pos.x += 0.2f; // This pushes tank to the right
            }
            else if (side == Side.Right)
            {
                pos.x -= 0.2f; // This pushes tank to the left
            }

            Object.GetComponent<Transform>().position = pos;

            /* Test code. Instantiates a sprite to show trigger is working
             * OutOfBounds.GetComponent<SpriteRenderer>().enabled = true; 
             */
        }

        if (Object.CompareTag("Alien"))
        {
            //Vector2 pos = Object.GetComponentInParent<Transform>().localPosition;
            //Object.GetComponent<Transform>().position = pos;

            if (side == Side.Left && PlayerManager.instance.alienSide == Side.Left)
            {
                Debug.Log("Left");
                Transform[] aliens = Object.transform.parent.GetComponentsInChildren<Transform>();
                foreach (Transform alien in aliens)
                {
                    Vector3 pos = alien.position;
                    pos.y -= 0.2f;
                    alien.position = pos;
                }
                //pos.y -= 1; // This pushes alien down
                //Object.transform.parent.transform.position = pos;
                //Debug.Log(Object.transform.parent.name);
                PlayerManager.instance.alienSide = Side.Right;
            }
            else if (side == Side.Right && PlayerManager.instance.alienSide == Side.Right)
            {
                Debug.Log("Right");
                Transform[] aliens = Object.transform.parent.GetComponentsInChildren<Transform>();
                foreach (Transform alien in aliens)
                {
                    Vector3 pos = alien.position;
                    pos.y -= 0.2f;
                    alien.position = pos;
                }
                //pos.y -= 1;
                //Object.transform.parent.transform.position = pos;
                PlayerManager.instance.alienSide = Side.Left;
            }
        }
    }

    private void Awake()
    {
        /*bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.size = new Vector2(1.3f, 1.3f);
        bc.isTrigger = true;

        rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Kinematic;*/
    }

    void Start()
    {

    }
}