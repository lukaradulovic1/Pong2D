using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpMode : MonoBehaviour
{
    public BallMovement ballMovement;
    public float interval = 5f;
    public float speedIncreaseAmount = 1f;
    private float nextTick;

    public void StartMode()
    {
        nextTick = Time.time + interval;
    }

    private void Update()
    {
        if (Time.time >= nextTick)
        {
            ballMovement.IncreaseSpeed(speedIncreaseAmount);
            nextTick += interval;
            Debug.Log("5 seconds passed, speed increased");
        }
    }
}
