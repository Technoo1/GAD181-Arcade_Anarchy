using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SaveSystem.loadedScene = "MainMenu";
    }
}
