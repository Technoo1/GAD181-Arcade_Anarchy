using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microgame : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnEnemies;
    public Gradient enemyGradient;
    public float timeBetweenSpawns = 1;

    public void Start()
    {
        StartCoroutine(SpawnEnemeies());

    }
    private IEnumerator SpawnEnemeies()
    {
        for (int i = 0; i < spawnEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            Color c = enemyGradient.Evaluate(Random.Range(0f, 1f));
            enemy.GetComponent<EnemyScript>().ChangeColor(c);
            yield return new WaitForSeconds(timeBetweenSpawns);

        }
    }
}
