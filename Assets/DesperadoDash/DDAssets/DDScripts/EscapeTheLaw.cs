using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeTheLaw : MonoBehaviour
{
    public GameObject escapeThe, law;
    public GameObject obstacleSpawner;

    public AudioSource gunshot;
    public AudioSource whip;

    public AudioSource bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OnSceneStart());
    }

    private void OnEnable()
    {



    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnSceneStart()
    {
        obstacleSpawner.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        gunshot.Play(0);
        escapeThe.SetActive(true);
        yield return new WaitForSeconds(1f);
        law.SetActive(true);
        escapeThe.SetActive(false);
        whip.Play(0);
        yield return new WaitForSeconds(1f);
        bgMusic.Play(0);
        yield return new WaitForSeconds(1f);
        obstacleSpawner.SetActive(true);
        law.SetActive(false);
    }
}
