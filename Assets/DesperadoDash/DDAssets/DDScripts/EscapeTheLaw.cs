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
        StartCoroutine(OnSceneStart()); //on the first frame, this starts the coroutine
    }

    private void OnDisable() //when the scene is unloaded, stop playing the music
    {
        bgMusic.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnSceneStart()
    {
        obstacleSpawner.SetActive(false);           //disables obstacle spawning while the sequence plays
        yield return new WaitForSeconds(0.5f);      //wait half a second
        gunshot.Play(0);                            //plays the gunshot sound effect
        escapeThe.SetActive(true);                  //shows the "Escape the" sprite
        yield return new WaitForSeconds(1f);        //wait one second
        law.SetActive(true);                        //sets the second state of the sprite to active, disables the first sprite and plays a whip sound effect
        escapeThe.SetActive(false);
        whip.Play(0);
        yield return new WaitForSeconds(1f);        //wait another second
        bgMusic.Play(0);                            //start background music
        yield return new WaitForSeconds(1f);        //wait one more second
        obstacleSpawner.SetActive(true);            //enable obstacle spawning, the game begins!!
        law.SetActive(false);                       //disable the second sprite
    }
}
