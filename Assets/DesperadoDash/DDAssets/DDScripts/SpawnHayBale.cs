using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHayBale : MonoBehaviour
{
    private float spawnTime;
    public bool isSpawn;
    public List<Transform> spawnLanes;
    public GameObject hayBale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawn)
        {
            StartCoroutine(HayBaleSpawn());
        }
    }

    public IEnumerator HayBaleSpawn()
    {
        isSpawn = true;
        spawnTime = Random.Range(5f, 7f);
        Transform randomTransform = spawnLanes[Random.Range(0, spawnLanes.Count)];
        yield return new WaitForSeconds(spawnTime);
        Instantiate(hayBale, randomTransform.position, randomTransform.rotation);
        isSpawn = false;
    }
}
