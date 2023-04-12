using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ArcadeAnarchy;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public bool isPaused;

    public void Awake()
    {

    }

    private void OnEnable()
    {
        Debug.Log("Seting up menu");
        EventManager.instance.OnTriggerGameOver += TriggerGameOver;
    }

    private void OnDisable()
    {
        Debug.Log("UI Scene Unloaded");
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
            optionsMenu.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void TriggerGameOver(TicketTier tier)
    {
        Debug.Log("Triggered Game Over" + name);
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SaveSystem.loadedScene);
        SaveSystem.loadedScene = "GameOver";
        StartCoroutine(WaitForTriggerTicket(tier));

    }

    private IEnumerator WaitForTriggerTicket(TicketTier tier)
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Trigger Ticket Tier");
        ScoreManager.instance.TriggerTicketTier(tier);
    }
}

