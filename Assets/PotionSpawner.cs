using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject potionToSpawn;
    public BP_Timer bp_Timer;
    public float timeBeforeFirstSpawn = 1f;
    public float timeBeforeSpawn = 20f;
    public int potionCount;
    Vector3 spawnTransform;


    void Start()
     {
        StartCoroutine(SpawnPotion());
    }

    IEnumerator SpawnPotion()
    {
        GameObject largestBall;
        largestBall = GameObject.FindWithTag("Potion");

        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        while (!largestBall)
        {
            Instantiate(potionToSpawn, transform); //... instantiate a target object
            //Debug.Log("intel spawned at " + this.gameObject.name);
            potionCount++;
            //Debug.Log(intelCount + " Intel is present");
            yield return new WaitForSeconds(timeBeforeSpawn);
        }

        if (largestBall)
        {
            Instantiate(potionToSpawn);
        }
    }


}
