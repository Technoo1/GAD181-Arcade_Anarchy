using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HSIntelScore : MonoBehaviour
{
    public static float playerIntel;
    public TMP_Text intelCounter;

    void Update()
    {
        intelCounter.text = playerIntel.ToString();
    }
}
