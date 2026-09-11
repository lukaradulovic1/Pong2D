using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpMode : MonoBehaviour
{
    [SerializeField] private float interval = 5f;
    [SerializeField] private float speedIncreaseAmount = 1f;

    public void StartGame(Ball ball)
    {
        StartCoroutine(SpeedUpLoop(ball));
    }

    private IEnumerator SpeedUpLoop(Ball ball)
    {
        BallMovement ballMovement = ball.GetComponent<BallMovement>();
        while (true)
        {
            yield return new WaitForSeconds(interval);

            ballMovement.IncreaseSpeed(speedIncreaseAmount);
        }
    }
}
