using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction; 
    public float speed;
    public System.Action destroyed;
    private ScreenShake cameraShake;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<ScreenShake>();
    }
    private void Update() // Generic code to generate projectiles.
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //Checks bullet collision
    {
        if(collision.tag != "BulletIgnore") // Checks to see if collided with ANYTHING.
        {
            Debug.Log(collision.name);
            this.destroyed.Invoke();
            Destroy(this.gameObject); //If collision is true destroys bullet

            if (collision.tag == "Alien") // Checks to see if collided specifically with the Aliens.
            {
                cameraShake.ShakeScreen(); // Script to cause Camera shake once alien is killed.
            }
        }        

        /*
         * MAYBE HAVE THIS AS RAIL GUN CODE? FOR SOME REASON KILLS ENTIRE ROW, DON'T KNOW WHY!!!!!
        if(collision.tag != "BulletIgnore")
        {
            Debug.Log(collision.name);
            this.destroyed.Invoke();
            StartCoroutine(cameraShake.Shake(.15f, .4f)); // Script to cause Camera shake once alien is killed.
            Destroy(this.gameObject); //If collision is true destroys bullet
        }       
        */ 
    }
}
