using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject defaultCanvas;
    public bool playIntro;

    public GameObject gameOverCanvas;
    public GameObject wayPointCanvas;

    public Text gameOverTitle;
    public Text gameOverDescription;
    public GameObject player;
    public GameObject introCam;

    public GameObject music;
    public GameObject ambience;

    private void Start()
    {
        music.SetActive(true);
        ambience.SetActive(true);
        player.SetActive(true);
        defaultCanvas.SetActive(true);
        //wayPointCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        if (playIntro)
        {
            introCam.SetActive(true);
        }
    }

    public void GameOver(bool win, string desc)
    {
        defaultCanvas.SetActive(false);
        //wayPointCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        if (win)
        {
            gameOverTitle.text = "You Win";
        } else if (!win)
        {
            gameOverTitle.text = "Game Over";
        }
        gameOverDescription.text = desc;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.SetActive(false);
        music.SetActive(false);
        ambience.SetActive(false);
    }
}