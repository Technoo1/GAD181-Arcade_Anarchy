using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;

    public SpriteRenderer sprite;

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    } 



    public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if (hitinfo.tag == "Player")
        {
           
            StartCoroutine(FlashRed());
        }
    }

    private void Update()
    {
        
    }


}

