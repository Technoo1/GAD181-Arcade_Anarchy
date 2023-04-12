using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public bool twoPlayer = true;
    public Side alienSide;
    public Side tankSide;

    public void Awake()
    {
        instance = this;
    }
}
