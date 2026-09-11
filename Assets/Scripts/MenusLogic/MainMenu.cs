using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioSource clip;
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject GameModesPanel; 

    private void Start()
    {
        clip.Play();
        if (GameOverController.OpenChangeMode)
        {
            MainMenuPanel.SetActive(false);
            GameModesPanel.SetActive(true);
            GameOverController.OpenChangeMode = false;
        }
        else
        {
            MainMenuPanel.SetActive(true);
            GameModesPanel.SetActive(false);
        }
    }
    public void PlayGame(int gameMode)
    {
        GameManager.SelectedGameMode = (GameMode)gameMode;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PauseMenu.GameIsPaused = false;
    }

    //public void LoadGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    PauseMenu.GameIsPaused = false;
    //    GameManager.ShouldLoadGame = true;
    //    Debug.Log("hit");
    //}

    public static void QuitGame()
    {
        Application.Quit();
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
