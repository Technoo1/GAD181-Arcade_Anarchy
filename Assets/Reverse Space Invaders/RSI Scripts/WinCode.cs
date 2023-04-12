using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCode : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.name == "Alien 1(Clone)")
        {
            SceneManager.LoadScene("MenuScreen");
        }
        else if (Object.name == "Alien 2(Clone)" )
        {
            SceneManager.LoadScene("MenuScreen");
        }
        else if (Object.name == "Alien 3(Clone)")
        {
            SceneManager.LoadScene("MenuScreen");
        }
    }
}
