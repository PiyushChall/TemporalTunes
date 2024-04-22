using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public int MainMenu = 0;


    private static bool ispaused = false;

    public GameObject pauseMenuUI;

    public static bool IsPaused { 
        get => ispaused; 
        private set { 
            ispaused = value;
            if(ispaused)
                Time.timeScale = 0f;
            else 
                Time.timeScale = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        IsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        IsPaused = true;
    }
    public void mainMenu()
    {
        IsPaused = false;
        SceneManager.LoadScene(MainMenu);
    }
    public void quit()
    {
        Application.Quit();
    }
}
