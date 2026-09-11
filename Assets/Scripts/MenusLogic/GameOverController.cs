using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI winnerText;
    public static bool OpenChangeMode { get; set; }

    public void ShowGameOverAndDeclareWinner(string winner)
    {
        gameOverPanel.SetActive(true);
        winnerText.text = $"Winner is {winner}!!!";
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    

    public void ChangeMode()
    {
        Time.timeScale = 1;
        OpenChangeMode = true;
        SceneManager.LoadScene(0);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

}
