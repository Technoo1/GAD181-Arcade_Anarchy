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
        spawnTime = Random.Range(0.5f, 1f);
        ScoreEvents.instance.OnThousandMeters += ThousandMeters;
        ScoreEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
        tumbleweedSpawnTime = Random.Range(5f, 10f);
    }

    void FiveHundredMeters()
    {
        spawnTime = Random.Range(0.4f, 0.8f);
        tumbleweedSpawnTime = Random.Range(3f, 7f);
    }
    void ThousandMeters()
    {
        spawnTime = Random.Range(0.3f, 0.6f);
        tumbleweedSpawnTime = Random.Range(1f, 5f);
    }

    void Update()
    {
        if (!isSpawn)
        {
            StartCoroutine(SpawnObstacles());
 
        }
        if (!isTumbleweed)
        {
            StartCoroutine(SpawnTumbleweed());
        }

    }
    
public IEnumerator SpawnObstacles()
    {
        isSpawn = true;
        GameObject randomObstacle = obstacleArray[Random.Range(0, obstacleArray.Length)];
        Transform randomTransform = spawnLanes[Random.Range(0, spawnLanes.Count)];
        yield return new WaitForSeconds(spawnTime);
        Instantiate(randomObstacle, randomTransform.position, randomTransform.rotation);
        isSpawn = false;
    }

    public IEnumerator SpawnTumbleweed()
    {

        isTumbleweed = true;
        yield return new WaitForSeconds(tumbleweedSpawnTime);
        Instantiate(tumbleweed, tumbleweedTransform.position, tumbleweedTransform.rotation);
        isTumbleweed = false;
    }
}
