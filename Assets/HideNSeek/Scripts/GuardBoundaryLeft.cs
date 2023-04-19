using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardBoundaryLeft : MonoBehaviour
{
    private GameObject Guard;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Guard = GameObject.FindGameObjectWithTag("GuardProfileL");
        Guard.GetComponent<HSGuardVision>().moveLeft = false;
        Debug.Log("guard out of bounds");
    }
}
