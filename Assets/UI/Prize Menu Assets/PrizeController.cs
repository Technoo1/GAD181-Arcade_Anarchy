using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeController : MonoBehaviour
{
    public int Tickets { get { return SaveSystem.currentTickets; } set { SaveSystem.currentTickets = value; } }
    public Image image;

    public string itemName;
    public int cost;

    public bool isPurchased = false;
    private GameObject canvas;
    private ScoreManager scoreManager;

    private UIAudioManager uiAudio;
    private GameObject uiAudioGameObject;
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

        uiAudioGameObject = GameObject.Find("UIAudioManager");
        uiAudio = uiAudioGameObject.GetComponent<UIAudioManager>();
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
        //if (Input.GetKeyDown(KeyCode.K))     this is just for testing purposes
        //{
        //    SaveSystem.currentTickets += 450;
        //}
    }
    public void ResetPrizeItem()
    {
        isPurchased = false;
        image.color = Color.black;
    }
    public void OnItemClicked()
    {
        if (!isPurchased && cost <= Tickets)
        {
            Debug.Log("pressed");
            image.color = Color.white;
            PlayerPrefs.SetInt(itemName, 1);
            isPurchased = true;

            SaveSystem.currentTickets -= cost;
            if (GameObject.Find("EpicSalmon"))
            {
                uiAudio.PlaySound("EpicSalmon");
            }
            else
            {
                uiAudio.PlaySound("ItemBought");
            }

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
