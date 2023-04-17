using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSIntelCollectable : MonoBehaviour
{
    float intelValue = 1;
    public GameObject audioPrefab;

 private void OnDestroy()
    {
        HSIntelScore.playerIntel += intelValue;
        Instantiate(audioPrefab);
        //Debug.Log("collected " + intelValue + " Intel");
    }
}