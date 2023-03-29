using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction; 

    public float speed;

    private void Update() // Generic code to generate projectiles.
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
}
