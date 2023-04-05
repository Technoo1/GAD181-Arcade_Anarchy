using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerManager.instance.twoPlayer = false;
        SceneManager.LoadScene("Reverse Space Invaders", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Player Selection");
    }
    public void PlayGame2Player()
    {
        PlayerManager.instance.twoPlayer = true;
        SceneManager.LoadScene("Reverse Space Invaders", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Player Selection");
    }
}
