using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    Rigidbody2D opponentPaddle;
    public float speed = 3f;
    public float reactionDelay = 0.1f;
    private float timer = 0f;
    private Ball targetBall;
    void Start()
    {
        opponentPaddle = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            timer = reactionDelay;
            targetBall = FindTargetBall();
        }

        if (targetBall != null)
        {
            float newY = Mathf.MoveTowards(opponentPaddle.position.y, PredictBallY(targetBall), speed * Time.fixedDeltaTime);
            opponentPaddle.position = new Vector2(opponentPaddle.position.x, newY);
        }
    }

    private Ball FindTargetBall()
    {
        float closestDistance = Mathf.Infinity;
        Ball targetBall = null;
        var activeBalls = GameManager.Instance.ballSpawner.activeBalls;
        float distance = 0f;

        foreach (var ball in activeBalls)
        {
            if (ball.RigidBody.velocity.x > 0)
            {
                distance = opponentPaddle.position.x - ball.Position.x;
                if (distance >= 0 && distance < closestDistance)
                {
                    closestDistance = distance;
                    targetBall = ball;
                }
            }
        }
        return targetBall;
    }

    private float PredictBallY (Ball ball)
    {

        float top = 12.611f;
        float bottom = -1.33f;
        float overshoot;
        float time = (opponentPaddle.position.x -  ball.RigidBody.position.x) / ball.RigidBody.velocity.x;
        float predictedY = ball.Position.y + ball.RigidBody.velocity.y * time;

        if (predictedY > top)
        {
            overshoot = predictedY - top;
            predictedY = top - overshoot;
        }
        else if (predictedY < bottom)
        {
            overshoot = bottom - predictedY;
            predictedY = bottom + overshoot;
        }
        return predictedY;
    }
}
