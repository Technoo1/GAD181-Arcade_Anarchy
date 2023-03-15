using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//wait x seconds to spawn Intel in scene
//Intel spawns at spawn points this location is attached to
//practically identical to guard spawns

public class HSIntelSpawn : MonoBehaviour
{
    public GameObject intelPrefab; //manually defined sprite prefab to spawn in inspector
    public float timeBeforeSpawn = 2f; //manually defined delay in seconds before spawning an enemy
    public bool isThereIntel;

    IEnumerator SpawnIntel() //coroutine to wait defined time before spawning enemies
    {
        bool playerIsPeeking = gameObject.GetComponent<SpriteRenderer>().sprite == playerPeek; //playerPeek Sprite must be active


        for (int i = 0; i < 100000000; i++) //loops the coroutine for a gajillion amount of seconds
        {
            if (isThereIntel == false)
            {
                yield return new WaitForSeconds(timeBeforeSpawn); //wait for seconds defined in "timeBeforeSpawn"
                Instantiate(intelPrefab, transform); //instantiate manually defined sprite
                bool Intel;
                Debug.Log("SpawnIntel coroutine at " + this.gameObject.name + " is done");
            }
        }
    }

    void Start()
    {
        StartCoroutine(SpawnIntel());
        Debug.Log("SpawnIntel coroutine has started");
    }

    void Update()
    {
        if (isThereIntel == true)
        {
            StopCoroutine(SpawnIntel));
        }
    }

    //event trigger relating to game start (scene change?) which starts SpawnGuard coroutine
    //test trigger with a key press, use g for guard lol
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        StartCoroutine(SpawnGuard());
    //        Debug.Log("SpawnGuard coroutine has started");
    //    }
    //}
}
