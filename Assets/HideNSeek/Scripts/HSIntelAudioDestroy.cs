using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSIntelAudioDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
