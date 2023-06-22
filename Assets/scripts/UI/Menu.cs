using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           isGamePaused = !isGamePaused;
           PauseGame();
        }   
    }

    public void PauseGame()
    { 
        if (isGamePaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
