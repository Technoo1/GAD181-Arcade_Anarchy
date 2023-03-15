using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public List<Transform> spawnLanes;
    public GameObject[] obstacleArray;

    public bool isSpawn = false;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(0.5f, 1f);
        ScoreEvents.instance.OnThousandMeters += ThousandMeters;
        ScoreEvents.instance.OnFiveHundredMeters += FiveHundredMeters;
    }

    void FiveHundredMeters()
    {
        spawnTime = Random.Range(0.4f, 0.8f);
    }
    void ThousandMeters()
    {
        spawnTime = Random.Range(0.3f, 0.6f);
    }

    void Update()
    {
        if (!isSpawn)
        {
        StartCoroutine(SpawnObstacles());
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
}
