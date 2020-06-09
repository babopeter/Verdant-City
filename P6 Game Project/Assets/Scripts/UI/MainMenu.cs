using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject defaultCanvas;
    public GameObject waypointCanvas;
    public GameObject gameOverCanvas;
    public GameObject player;
    public void PlayGame()
    {
        // Delay scene loading by 1s so the "UI_click" sound has time to play
        Invoke("LoadScene", 1.0f);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        /*
        defaultCanvas.SetActive(true);
        waypointCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        player.SetActive(true);
        */
        HandleLife.currentHealth = 1.0f;
        HandleEnvironment.environmentHealth = 0.7f;
        HandleInventory.scrap = 0;
        HandleInventory.wood = 0;
        HandleInventory.electronics = 0;
        SceneManager.LoadScene(0);
    }
}
