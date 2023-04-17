using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSIntelAudioDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
