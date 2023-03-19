using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI uiText;
    public void Awake()
    {
        ArcadeAnarchy.EventManager.instance.OnUpdateUI += UpdateUI;
    }

    public void UpdateUI(string text)
    {
        uiText.SetText(text);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }
}

