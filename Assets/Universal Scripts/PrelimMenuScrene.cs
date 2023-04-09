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
        Time.timeScale = 1f;
        SceneManager.LoadScene("DesperadoDash");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void HideNSeek()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HideNSeek");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void Ballpocalypse()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Ballpocalypse");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void CentipedeBreakout()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CentipedeTesting");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void RevSpaceInvaders()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Reverse Space Invaders");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
        Time.timeScale = 1f;
    }

    public void QuitGameSave()
    {
        Application.Quit();
        Debug.Log("quit game (Saved Data)");
    }

    public void QuitGameDelete()
    {
        Application.Quit();
        Debug.Log("quit game (Deleted Data)");
        SaveSystem.DeleteData();
    }

    private void TriggerGameOver()
    {

        SceneManager.LoadScene("GameOver");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
        //SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        //SceneManager.UnloadSceneAsync("UI Scene");
    }

    public void PrizeMenu()
    {
        SceneManager.LoadScene("PrizeMenu");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }


    public void LoadScore()
    {
        SaveSystem.LoadTickets();
    }
}
