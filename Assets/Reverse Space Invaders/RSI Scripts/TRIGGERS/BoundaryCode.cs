using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCode : MonoBehaviour
{
    public GameObject OutOfBounds;
    public string side;

    private void OnTriggerEnter2D(Collider2D collider) // Checks object name and executes this code if collided
    {
        Debug.Log("Been hit");
        if (collider.CompareTag("Alien"))
        {
            // Gets the transform (position) of the Alien 
            Vector2 pos = collider.GetComponent<Transform>().position;
            collider.GetComponent<Transform>().position = pos;

            if (side == "Left 2")
            {
                pos.x += 10f; // This pushes Alien to the right
                collider.gameObject.transform.position = pos;
                Debug.Log("Been Triggered");
            }
            else if (side == "Right 2")
            {
                pos.x -= 10f; // This pushes Alien to the left
                collider.gameObject.transform.position = pos;
            }
        }
    }
}
