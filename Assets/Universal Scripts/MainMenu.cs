using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MenuScreen");
        //SceneManager.UnloadSceneAsync("MainMenu");
        SaveSystem.loadedScene = "MenuScreen";
        Time.timeScale = 1f;
    }

    public void QuitGameSave()
    {
        Application.Quit();
        Debug.Log("quit game (Saved Data)");
    }

    public void LoadScore()
    {
        SaveSystem.LoadTickets();
    }
}
