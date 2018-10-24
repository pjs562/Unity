using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject playScreen;
    public GameObject pauseButton;
    private GameObject ButtonSound;

    private void Start()
    {
        ButtonSound = GameObject.Find("ButtonSound");
    }
    public void Paused()
    {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
    }
    public void Resume ()
    {
        Instantiate(ButtonSound);
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        playScreen.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        Instantiate(ButtonSound);
        pauseButton.SetActive(false);
        playScreen.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Instantiate(ButtonSound);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Instantiate(ButtonSound);
        Application.Quit();
    }

}
