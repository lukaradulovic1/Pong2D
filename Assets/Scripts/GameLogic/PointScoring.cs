using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointScoring : MonoBehaviour
{
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI opponentScore;
    public int playerPoints = 0, opponentPoints = 0; 
    public int PlayerPoints => playerPoints;
    public int OpponentPoints => opponentPoints;
    public event System.Action OnScoreChanged;
    public event System.Action<Ball> OnBallScored;

    public void ScorePointForPlayer(Ball ball)
    {
        playerPoints++;
        playerScore.text = "Player: " + playerPoints;

        Debug.Log(ball.gameObject.name);
        OnBallScored?.Invoke(ball);

        OnScoreChanged?.Invoke();
    }
    public void ScorePointForOpponent(Ball ball)
    {
        opponentPoints++;
        opponentScore.text = "Opponent: " + opponentPoints;

        Debug.Log(ball.gameObject.name);

        OnBallScored?.Invoke(ball);

        OnScoreChanged?.Invoke();
    }

    public void ResetScore()
    {
        playerPoints = 0;
        opponentPoints = 0;

        playerScore.text = "Player: 0";
        opponentScore.text = "Opponent: 0";
    }

}
