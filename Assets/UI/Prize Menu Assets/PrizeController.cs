using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeController : MonoBehaviour
{
    public Image image;

    public string itemName;
    public int cost;

    public bool isPurchased = false;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        isPurchased = PlayerPrefs.GetInt(itemName, 0) == 1;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().color == Color.white)
        {
            isPurchased = true;
            PlayerPrefs.SetInt(itemName, 1);
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKey(KeyCode.D))
            {
                ResetPrizeItem();
            }
        }
    }
    public void ResetPrizeItem()
    {
        isPurchased = false;
        image.color = Color.black;
    }
    public void OnItemClicked()
    {
        Debug.Log("pressed");
        image.color = Color.white;
        isPurchased = true;
        PlayerPrefs.SetInt(itemName, 1);
    }

    void UpdateUI()
    {
        if (isPurchased)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.black;
        }
    }
}
