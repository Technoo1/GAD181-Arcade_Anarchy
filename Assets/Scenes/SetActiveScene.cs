using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcadeAnarchy;
using UnityEngine.SceneManagement;

public class SetActiveScene : MonoBehaviour
{
    //put this scene in a game to have it load 
    void Start()
    {
        Debug.Log("AAHHHAHAhhhhhhhhggrggu");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SaveSystem.loadedScene));
    }
}
