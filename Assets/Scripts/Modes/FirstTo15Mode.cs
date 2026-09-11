using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTo15Mode : MonoBehaviour
{
    [SerializeField] private int winningScore = 15;
    [SerializeField] GameOverController gameOverController;

    public void StartGame()
    {
        GameManager.Instance.pointScoring.OnScoreChanged += CheckWinner;
    }

    private void CheckWinner()
    {
        if (GameManager.Instance.pointScoring.PlayerPoints >= winningScore)
        {
            Debug.Log("Player wins!");
            GameManager.Instance.pointScoring.OnScoreChanged -= CheckWinner;
            gameOverController.ShowGameOverAndDeclareWinner("Player");
        }
        else if (GameManager.Instance.pointScoring.OpponentPoints >= winningScore)
        {
            Debug.Log("Opponent wins!");
            GameManager.Instance.pointScoring.OnScoreChanged -= CheckWinner;
            gameOverController.ShowGameOverAndDeclareWinner("Opponent");

        }
    }
}
