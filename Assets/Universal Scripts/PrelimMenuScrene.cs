using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrelimMenuScrene : MonoBehaviour
{
    public void DesDash()
    {
        SceneManager.LoadScene("DesperadoDash");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void HideNSeek()
    {
        SceneManager.LoadScene("HideNSeek");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void Ballpocalypse()
    {
        SceneManager.LoadScene("Ballpocalypse");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void CentipedeBreakout()
    {
        SceneManager.LoadScene("CentipedeBreakout");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }
    public void RevSpaceInvaders()
    {
        SceneManager.LoadScene("ReverseSpaceInvaders");
        SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
