using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrelimMenuScreen : MonoBehaviour
{
    public string sceneToLoad;
    private void Start()
    {
        Scene currentScene = SceneManager.GetSceneByName("UI Scene");

        if (currentScene.name != sceneToLoad)
        {
            SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
            Debug.Log("Loaded UI" + name);
            SaveSystem.loadedScene = "MenuScene";
        }


    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MenuScreen", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SaveSystem.loadedScene);
        SaveSystem.loadedScene = "MenuScreen";
        Time.timeScale = 1f;
    }
    public void DesDash()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("DesperadoDash", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MenuScreen");
        SaveSystem.loadedScene = "DesperadoDash";
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
