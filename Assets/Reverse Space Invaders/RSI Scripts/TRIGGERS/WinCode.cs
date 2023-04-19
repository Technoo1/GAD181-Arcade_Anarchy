using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCode : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.CompareTag("Alien"))
        {
            SceneManager.LoadScene("MenuScreen");
        }
    }
}
