using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public List<Transform> spawnLanes;
    public GameObject[] obstacleArray;

    public bool isSpawn = false;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        float spawnTime = Random.Range(1, 2);
        yield return new WaitForSeconds(spawnTime);
        Instantiate(randomObstacle, randomTransform.position, randomTransform.rotation);
        isSpawn = false;
    }
}
