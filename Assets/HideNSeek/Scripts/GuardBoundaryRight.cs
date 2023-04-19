using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBoundaryRight : MonoBehaviour
{
    private GameObject Guard;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Guard = GameObject.FindGameObjectWithTag("GuardProfile");
        Guard.GetComponent<HSGuardVision>().moveRight = false;
        Debug.Log("guard out of bounds");
    }
}
