using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeScript : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        Debug.Log("pressed");
        image.color = new Color32(255, 255, 255, 255);
    }


}
