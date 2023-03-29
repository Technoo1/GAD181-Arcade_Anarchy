using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrelimMenuScrene : MonoBehaviour
{
    private void Start()
    {
        EventManager.instance.OnTriggerGameOver += TriggerGameOver;
    }
    public void DesDash()
    {
        SceneManager.LoadScene("DesperadoDash");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void HideNSeek()
    {
        SceneManager.LoadScene("HideNSeek");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void Ballpocalypse()
    {
        SceneManager.LoadScene("Ballpocalypse");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void CentipedeBreakout()
    {
        SceneManager.LoadScene("CentipedeTesting");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void RevSpaceInvaders()
    {
        SceneManager.LoadScene("Reverse Space Invaders");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }

    private void TriggerGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }
}
