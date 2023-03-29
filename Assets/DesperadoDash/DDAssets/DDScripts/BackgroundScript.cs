using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private float scrollSpeed, startScrollSpeed = 0.5f;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;

        ScoreEvents.instance.OnThousandMeters += ThousandMeters;
        ScoreEvents.instance.OnFiveHundredMeters += FiveHundredMeters;

        offset = 0f;
        scrollSpeed = startScrollSpeed;
    }
    

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    void FiveHundredMeters()
    {
        scrollSpeed = 2.25f;
    }
    void ThousandMeters()
    {
        scrollSpeed = 2.5f;
    }
}
