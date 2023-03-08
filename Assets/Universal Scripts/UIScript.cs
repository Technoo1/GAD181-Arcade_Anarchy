using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIScript : MonoBehaviour
{

    public TextMeshProUGUI uiText;
    public void Awake()
    {
        EventManager.instance.OnUpdateUI += UpdateUI;
    }

    public void UpdateUI(string text)
    {
        uiText.SetText(text);
    }

}

