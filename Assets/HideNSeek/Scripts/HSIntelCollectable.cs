using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSIntelCollectable : MonoBehaviour
{
    float intelValue = 1;

    private void OnDestroy()
    {
        HSIntelScore.playerIntel += intelValue;
        Debug.Log("collected " + intelValue + " Intel");
    }
}
