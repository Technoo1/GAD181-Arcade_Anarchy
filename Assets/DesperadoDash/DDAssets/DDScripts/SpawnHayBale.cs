using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHayBale : MonoBehaviour
{
    private float spawnTime;
    public bool isSpawn;
    public List<Transform> spawnLanes;
    public GameObject hayBale;


    // Update is called once per frame
    void Update()
    {
        if (!isSpawn) //only play if not already playing
        {
            StartCoroutine(HayBaleSpawn());
        }
    }

    public IEnumerator HayBaleSpawn()
    {
        isSpawn = true;                                                             //makes sure another doesnt spawn at the same time
        spawnTime = Random.Range(15f, 25f);                                           //sets random spawn time
        Transform randomTransform = spawnLanes[Random.Range(0, spawnLanes.Count)];  //picks a random lane
        yield return new WaitForSeconds(spawnTime);                                 //waits for the spawn time that was set
        Instantiate(hayBale, randomTransform.position, randomTransform.rotation);   //instantiates a hay bale in the position and rotation of the lane
        isSpawn = false;                                                            //lets another one spawn
    }
}
