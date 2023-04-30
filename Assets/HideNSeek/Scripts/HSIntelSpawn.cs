using System.Collections;
using UnityEngine;

//wait x seconds to spawn Intel in scene
//Intel spawns at spawn points this location is attached to
//practically identical to guard spawns

public class HSIntelSpawn : MonoBehaviour
{
    public GameObject intelPrefab; //define sprite prefab to spawn in inspector
    public float timeBeforeFirstSpawn = 1f; //define delay in seconds before coroutine spawns first intel
    public float timeBeforeSpawn = 5f; //define delay in seconds before spawning an enemy
    public int intelCount; //value that determines whether Intel will spawn here

    void Start()
    {
        StartCoroutine(SpawnIntel());
        //Debug.Log("SpawnIntel coroutine at " + this.gameObject.name + " has started");
    }

    IEnumerator SpawnIntel() //coroutine to wait defined time before spawning enemies
    {
        GameObject intelObject;
        intelObject = GameObject.FindWithTag("Intel"); //defining the first object in a scene tagged as "Intel"

        yield return new WaitForSeconds(timeBeforeFirstSpawn); //first spawn delayed by x seconds defined here
        while (!intelObject) //while there's no object in the scene tagged as "Intel"...
        {
            Instantiate(intelPrefab, transform); //... instantiate a target object
            //Debug.Log("intel spawned at " + this.gameObject.name);
            intelCount++;
            //Debug.Log(intelCount + " Intel is present");
            yield return new WaitUntil(() => intelCount == 0); //pauses coroutine until there's 0 intel at this spawn
            yield return new WaitForSeconds(timeBeforeSpawn);
        }
    }
}
