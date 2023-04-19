using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CostText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;
    public PrizeController prizeCont;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!prizeCont.isPurchased)
        {
            text.gameObject.SetActive(true);
            text.text = "Purchase for " + prizeCont.cost + "Tickets?";
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.gameObject.SetActive(false);
    }
}
