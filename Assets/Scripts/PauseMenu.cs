using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioManager audioManager;


    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                Debug.Log("hit");
            }
            else
            {
                Pause();
                Debug.Log("hit");
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        audioManager.audioMusic.Play();
        Debug.Log("hit");
    }

    public void Pause()
    {
        Debug.Log("hit");

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        audioManager.audioMusic.Stop();
    }

    public void LoadMenu()
    {
        Debug.Log("hit");
        Time.timeScale = 1f;

        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("hit");
    }

    public void SaveAndQuit()
    {
       GameManager.Instance.SaveAndQuit();
    }
}
