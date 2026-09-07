using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioSource clip;


    private void Start()
    {
        clip.Play();
    }
    public void PlayGame(int gameMode)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PauseMenu.GameIsPaused = false;
        GameManager.ShouldLoadGame = false;
        GameManager.GameMode = (GameMode)gameMode;
        Debug.Log("hit");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PauseMenu.GameIsPaused = false;
        GameManager.ShouldLoadGame = true;
        Debug.Log("hit");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("hit");
    }
    public void PausePlayMusic()
    {
        if (clip.isPlaying)
        {
            clip.Pause();
        }
        else
        {
            clip.Play();
        }
    }

}
