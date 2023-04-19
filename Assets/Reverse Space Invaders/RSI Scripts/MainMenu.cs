using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource clickSource;
    public AudioClip clickSound;

    public void PlayGame()
    {
        clickSource = GetComponent<AudioSource>();
        clickSource.PlayOneShot(clickSound);
        PlayerManager.instance.twoPlayer = false;
        SceneManager.LoadScene("Reverse Space Invaders", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Player Selection");
    }
    public void PlayGame2Player()
    {
        clickSource = GetComponent<AudioSource>();
        clickSource.PlayOneShot(clickSound);
        PlayerManager.instance.twoPlayer = true;
        SceneManager.LoadScene("Reverse Space Invaders", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Player Selection");
    }
}
