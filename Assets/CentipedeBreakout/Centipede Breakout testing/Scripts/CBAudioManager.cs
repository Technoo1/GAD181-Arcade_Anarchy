using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBAudioManager : MonoBehaviour
{
    public static CBAudioManager instance;

    public event Action<string> OnUpdateUI; //Output, attach a string to the action
    public void UpdateUI(string text) //Input, passing a string to anything listening
    {
        OnUpdateUI?.Invoke(text);

        Resources.LoadAll<AudioClip>(text);
    }
}
