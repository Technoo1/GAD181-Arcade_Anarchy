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
    private GameObject canvas;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        //isPurchased = false;
        image = GetComponent<Image>();
        if (PlayerPrefs.HasKey(itemName))
        {
            isPurchased = PlayerPrefs.GetInt(itemName, 0) == 0;
        }
        else
        {
            isPurchased = false;
        }

        Debug.Log("Item: " + itemName + ", isPurchased: " + isPurchased);
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

        UpdateUI();
        
    }
    public void ResetPrizeItem()
    {
        isPurchased = false;
        image.color = Color.black;
    }
    public void OnItemClicked()
    {
        if (!isPurchased)
        {
            Debug.Log("pressed");
            image.color = Color.white;
            PlayerPrefs.SetInt(itemName, 1);
            isPurchased = true;

            SaveSystem.currentTickets -= cost;
        }

    }

    public void UpdateUI()
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
