using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrelimMenuScreen : MonoBehaviour
{
    public string sceneToLoad;
    private static bool uiSceneLoaded = false;
    private void Start()
    {
        if (!uiSceneLoaded)
        {
            StartCoroutine(LoadUISceneAsync());
            SaveSystem.loadedScene = "MenuScene";
        }
    }

    private IEnumerator LoadUISceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        uiSceneLoaded = true;
    }
    private void Update()
    {
        if (SceneManager.GetSceneByName("MenuScreen").isLoaded)
        {
            SaveSystem.loadedScene = "MenuScreen";
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SaveSystem.loadedScene = "MainMenu";
    }
    public void GameMenu()
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
        SceneManager.LoadSceneAsync("HideNSeek", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MenuScreen");
        SaveSystem.loadedScene = "HideNSeek";
    }
    public void Ballpocalypse()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Ballpocalypse", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MenuScreen");
        SaveSystem.loadedScene = "Ballpocalypse";

    }
    public void CentipedeBreakout()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("CentipedeTesting", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MenuScreen");
        SaveSystem.loadedScene = "CentipedeTesting";
    }
    public void RevSpaceInvaders()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Player Selection", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MenuScreen");
        SaveSystem.loadedScene = "Player Selection";
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
        SceneManager.LoadSceneAsync("PrizeMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MenuScreen");
        SaveSystem.loadedScene = "PrizeMenu";
    }
    public void LoadScore()
    {
        SaveSystem.LoadTickets();
    }
}
