using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MenuScreen");
        //SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
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


    public void QuitGameDelete()
    {
        Application.Quit();
        Debug.Log("quit game (Deleted Data)");
        SaveSystem.DeleteData();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        SaveSystem.loadedScene = "Credits";
    }
}
