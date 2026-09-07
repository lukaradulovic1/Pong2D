using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleBallsMode : MonoBehaviour
{
    public float interval = 5f;
    private float nextTick = 5f;
    public GameManager gameManager;

    int currentBalls = 1;
    public GameObject ball;

    public void StartMode()
    {
        gameManager.AddBall(ball);
        nextTick = Time.time + interval;
    }

    private void Update()
    {
        if (Time.time >= nextTick)
        {
            Debug.Log("Current balls " + currentBalls);
            GameObject newBall = Instantiate(ball);
            gameManager.AddBall(newBall);
            currentBalls++;
            Debug.Log("Ball count: " + currentBalls);
            nextTick = Time.time + interval;
        }
    }

}
