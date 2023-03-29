using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCode : MonoBehaviour
{
    public GameObject WinArea;

    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.name == "Alien")
        {
            WinArea.GetComponent<SpriteRenderer>().enabled = true; 
        }
    }
}
