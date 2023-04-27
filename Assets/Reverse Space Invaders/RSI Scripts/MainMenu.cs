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
        SceneManager.LoadSceneAsync("Reverse Space Invaders", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Player Selection");
        SceneManager.UnloadSceneAsync(SaveSystem.loadedScene);
        SaveSystem.loadedScene = ("Reverse Space Invaders");
        Debug.Log("Code is being triggered.");
    }
    public void PlayGame2Player()
    {
        clickSource = GetComponent<AudioSource>();
        clickSource.PlayOneShot(clickSound);
        PlayerManager.instance.twoPlayer = true;
        SceneManager.LoadSceneAsync("Reverse Space Invaders", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Player Selection");
        SceneManager.UnloadSceneAsync(SaveSystem.loadedScene);
        SaveSystem.loadedScene = ("Reverse Space Invaders");
    }

    public void DebugFunc()
    {
        Debug.Log("uhhhh");
    }
}
