using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MultipleBallsMode : MonoBehaviour
{
    [SerializeField] private int minimumBalls = 3;

    [SerializeField] private float interval = 5f;
    private BallSpawner ballSpawner;
    private void Awake()
    {
        ballSpawner = FindObjectOfType<BallSpawner>();
    }

    public void StartGame()
    {
        ballSpawner.SpawnMultipleBall();
        ballSpawner.SpawnMultipleBall();
        ballSpawner.SpawnMultipleBall();

        GameManager.Instance.pointScoring.OnBallScored += DestroyPointScoringBall;
    }

    private IEnumerator SpawnBallLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            ballSpawner.SpawnBall();
            Debug.Log("new ball spawned");
        }
    }

    private void DestroyPointScoringBall(Ball ball)
    {
        ballSpawner.RemoveBall(ball);
        if (ballSpawner.activeBalls.Count < minimumBalls)
        {
            ballSpawner.SpawnBall();
        }
    }
}
