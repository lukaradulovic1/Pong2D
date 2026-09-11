using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public List<Ball> activeBalls = new List<Ball>();
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private SpeedUpMode speedUpMode;
    [SerializeField] private MultipleBallsMode multipleBallsMode;
    [SerializeField] private FirstTo15Mode firstTo15Mode;

    private void Awake()
    {
        
    }
    public void StartMode(GameMode gameMode)
    {
        Debug.Log("StartMode: " + gameMode);
        switch (gameMode)
        {       
            case GameMode.Normal:
                SpawnBall();
                break;
            case GameMode.SpeedUp:
                speedUpMode.StartGame(SpawnBall());
                break;
            case GameMode.MultipleBalls:
                multipleBallsMode.StartGame();
                break;
            case GameMode.FirstTo15Points:
                firstTo15Mode.StartGame();
                SpawnBall();
                break;
            default:
                break;
        }
    }

    public Ball SpawnBall()
    {
        Ball ball = Instantiate(ballPrefab);
        activeBalls.Add(ball);
        BallMovement movement = ball.GetComponent<BallMovement>();
        movement.StartBall();
        return ball;
    }

    public void RemoveBall(Ball ball)
    {
        activeBalls.Remove(ball);
        Destroy(ball.gameObject);
    }
    public Ball SpawnMultipleBall()
    {
        Ball ball = Instantiate(ballPrefab);
        activeBalls.Add(ball);

        BallMovement movement = ball.GetComponent<BallMovement>();
        movement.StartMultipleBall();

        return ball;
    }
}
