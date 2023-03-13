using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

//define the object (prefab) I want to spawn (it's always the profile sprite but this is flexible regardless)
//define the time to wait in seconds from microgame start before spawning the sprite (adjustable float is preferable)
//wait predefined time before instantiating guard
//trigger to start coroutine

public class HSGuardSpawn : MonoBehaviour
{
    //manually defined sprite to spawn in inspector
    public GameObject guardProfilePrefab;

    //manually defined delay in seconds before spawning an enemy
    public float timeBeforeSpawn = 1f;

    //coroutine to wait defined time before spawning enemies
    IEnumerator SpawnGuard()
    {
        //wait for seconds defined in "timeBeforeSpawn"
        yield return new WaitForSeconds(timeBeforeSpawn);

        //instantiate manually defined sprite
        Instantiate(guardProfilePrefab, transform);

        //print to console
        Debug.Log("SpawnGuard coroutine is done");
    }

    //event trigger relating to game start (scene change?) which starts SpawnGuard coroutine
    //test trigger with a key press, use g for guard lol
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(SpawnGuard());
            Debug.Log("SpawnGuard coroutine has started");
        }
    }
}
