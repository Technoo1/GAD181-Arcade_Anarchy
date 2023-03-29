using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameOverEvents : MonoBehaviour
{
    public bool isDead = false;

    // Start is called before the first frame update
    private void Awake()
    {

    }


    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameOver");
        }
    }
}
