using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
