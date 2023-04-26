using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballToSpawn;
    public BP_Timer bp_Timer;
    public float timeBeforeFirstSpawn = 0.5f;
    public float timeBeforeSpawn = 15f;
    public int ballCount;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBall()
    {
        GameObject largestBall;
        largestBall = GameObject.FindWithTag("Largest Ball");

        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        while (!largestBall)
        {
            Instantiate(ballToSpawn); //... instantiate a target object
            //Debug.Log("intel spawned at " + this.gameObject.name);
            ballCount++;
            //Debug.Log(intelCount + " Intel is present");
            yield return new WaitForSeconds(timeBeforeSpawn);
        }

      if (largestBall)
       {
            Instantiate(ballToSpawn);
            
       }
    }

}
