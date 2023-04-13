using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction; 

    public float speed;

    public System.Action destroyed;

    private void Update() // Generic code to generate projectiles.
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
        FindObjectOfType<LaserShot>().Play("LaserShot");
    }

    private void OnTriggerEnter2D(Collider2D collision) //Checks bullet collision
    {
        if(collision.tag != "BulletIgnore")
        {
            Debug.Log(collision.name);
            this.destroyed.Invoke();
            Destroy(this.gameObject); //If collision is true destroys bullet
        }        
    }
}
