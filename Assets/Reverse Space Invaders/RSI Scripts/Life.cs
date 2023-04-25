using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life;
    public string tagHit = "Laser";
    public List<Color> randColors;
    private ScreenShake cameraShake;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<ScreenShake>();
    }

    void Update()
    {
        if (life <= 0)
        {
            cameraShake.ShakeScreenCastle();
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(tagHit))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().color = randColors[Random.Range(0, randColors.Count)];

            if (gameObject.transform.GetComponent<SpriteRenderer>().color == randColors[Random.Range(0, randColors.Count)])
            {
                this.gameObject.transform.GetComponent<SpriteRenderer>().color = randColors[Random.Range(0, randColors.Count)];
            }

            if (life > 0)
            {
                cameraShake.BoomBabyBoom();
            }

            life--;
        }
    }
}
