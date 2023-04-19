using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private float scrollSpeed, startScrollSpeed;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material; //sanity check for the renderer

        DistanceEvents.instance.OnThousandMeters += ThousandMeters;
        DistanceEvents.instance.OnFiveHundredMeters += FiveHundredMeters;

        offset = 0f;
        scrollSpeed = startScrollSpeed;
    }
    

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f; //every frame the background material will offset by the speed divided by 10 (smoothened by Time.deltaTime)
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0)); //sets the material WITH the offset aka, background moves
    }

    void FiveHundredMeters() //at five hundred meters the scroll speed of the background changes to 2.25
    {
        scrollSpeed = 2.25f;
    }
    void ThousandMeters() //at one thousand meters the scroll speed of the background changes to 2.5
    {
        scrollSpeed = 2.5f;
    }
}
