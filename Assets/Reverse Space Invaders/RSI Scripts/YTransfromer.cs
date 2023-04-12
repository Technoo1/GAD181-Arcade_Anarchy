using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTransfromer : MonoBehaviour
{
    // Start is called before the first frame update
    public void TransformY()
    {
        Vector2 pos = GetComponent<Transform>().localPosition;
        pos.y -= 1;
        GetComponent<Transform>().localPosition = pos;
    }
}
