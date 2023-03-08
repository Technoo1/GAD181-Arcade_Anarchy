using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public event Action OnJump;
    public event Action OnRight;
    public event Action OnLeft;
    public event Action OnUp;
    public event Action OnDown;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            OnUp?.Invoke();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            OnLeft?.Invoke();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            OnDown?.Invoke();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            OnRight?.Invoke();
        }
    }
}
