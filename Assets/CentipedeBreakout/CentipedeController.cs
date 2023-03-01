using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CentipedeController : MonoBehaviour
{
    private Collider2D collider;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
