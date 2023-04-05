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

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnItemClicked()
    {
        Debug.Log("pressed");
        image.color = new Color32(255, 255, 255, 255);
        isPurchased = true;
    }
    //public void PurchaseConfirmation()
    //{
    //    if (!isPurchased)
    //    {
    //        purchCont.purchaseScreen.SetActive(true);
    //    }
    //}




}
