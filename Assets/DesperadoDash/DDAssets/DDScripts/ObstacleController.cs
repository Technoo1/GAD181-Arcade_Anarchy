using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public List<Transform> spawnLanes;
    public GameObject[] obstacleArray;

    public GameObject tumbleweed;
    public float tumbleweedSpawnTime;
    public Transform tumbleweedTransform;
    public bool isTumbleweed;

    public bool isSpawn = false;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {    
        DistanceEvents.instance.OnThousandMeters += ThousandMeters; //subscribe function to event
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters; //subscribe function to event
    }

    private void OnDisable() //unsubscribes functions from event when scene is unloaded
    {
        DistanceEvents.instance.OnThousandMeters -= ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters -= FiveHundredMeters;
    }

    void FiveHundredMeters()
    {
        spawnTime = Random.Range(0.4f, 0.8f); //faster spawn rates
        tumbleweedSpawnTime = Random.Range(3f, 7f); //faster tumbleweed spawn rates
    }
    void ThousandMeters()
    {
        spawnTime = Random.Range(0.3f, 0.6f);   //even faster spawn rates
        tumbleweedSpawnTime = Random.Range(1f, 5f); //even faster tumbleweed spawn rates
    }

    void Update()
    {
        if (!isSpawn) //only spawn an obstacle/start coroutine if its not already playing
        {
            StartCoroutine(SpawnObstacles());
 
        }
        if (!isTumbleweed) //only spawn tumbleweed/start coroutine if its not already playing
        {
            StartCoroutine(SpawnTumbleweed());
        }

    }
    
public IEnumerator SpawnObstacles()
    {
        isSpawn = true;                                                                     //stops coroutine from being played again until its done
        spawnTime = Random.Range(0.5f, 1f);                                                 //sets random spawn time
        GameObject randomObstacle = obstacleArray[Random.Range(0, obstacleArray.Length)];   //gets a random obstacle from the array
        Transform randomTransform = spawnLanes[Random.Range(0, spawnLanes.Count)];          //gets a random lane from the list of lanes
        yield return new WaitForSeconds(spawnTime);                                         //waits for the spawn time
        Instantiate(randomObstacle, randomTransform.position, randomTransform.rotation);    //instantiates the random obstacle determined earlier
        isSpawn = false;                                                                    //allows another obstacle to be spawned
    }

    public IEnumerator SpawnTumbleweed()
    {
        isTumbleweed = true;                                                                //stops coroutine from being played again until its done
        tumbleweedSpawnTime = Random.Range(5f, 10f);                                        //sets random spawn time for tumbleweed
        yield return new WaitForSeconds(tumbleweedSpawnTime);                               //waits for the spawn time
        Instantiate(tumbleweed, tumbleweedTransform.position, tumbleweedTransform.rotation);//instantiates tumbleweed
        isTumbleweed = false;                                                               //allows another one to be spawned
    }
}
