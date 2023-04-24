using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
   /* [SerializeField] GameObject[] potionPrefab;
    [SerializeField] float secondSpawn = 15f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

     void Start()
    {
        StartCoroutine(PotionSpawn());  
    }

    IEnumerator PotionSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(potionPrefab[Random.Range(0, potionPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    } */

}
