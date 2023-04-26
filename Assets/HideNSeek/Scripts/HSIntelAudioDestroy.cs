using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HSIntelAudioDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        if (SaveSystem.loadedScene == "HideNSeek")
        {
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(DestroyThis());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
