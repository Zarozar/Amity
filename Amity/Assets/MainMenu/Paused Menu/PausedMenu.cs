﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausedMenu : MonoBehaviour
{

    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;
    
    void Update ()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
            
    }

    public void LoadMenu()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        HealthTracker.PlayerHealth = 100;
        SceneManager.LoadScene("Mainmenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
