using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExampleGameManager : MonoBehaviour
{
    //To ensure that there's no conflicts on loading, we tell the SceneSwapper to load our scenes from Start here, to prevent script load execution errors
    void Start()
    {
        //Tell SceneSwapper to load the starting UI
        SceneSwapper.instance.LoadStartingUI();
        RandomSelectScene();
    }

    public void RandomSelectScene()
    {
        int random = Random.Range(0, SceneSwapper.instance.gameScenes.Length);

        //Also tell SceneSwapper to load the game scene at position 0
        SceneSwapper.instance.LoadScene(random);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneSwapper.instance.LoadUnloadScene(SceneSwapper.instance.CurrentScene);
            RandomSelectScene();
        }
    }
}
