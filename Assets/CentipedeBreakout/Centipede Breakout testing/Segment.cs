using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public GameObject attachedHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject + "Object clicked");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
