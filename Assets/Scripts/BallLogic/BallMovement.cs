using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Ball ball;
    private void Awake()
    {
        ball = GetComponent<Ball>();
    }
    private void SpeedIncreasePrint()
    {
        Debug.Log("5 seconds passed, speed increased");
    }

 

    public void StartBall()
    {
        float angle = Random.Range(-30f, 30f);
        float direction = Random.value < 0.5f ? -1f : 1f;

        Vector2 startDirection = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad) * direction,
            Mathf.Sin(angle * Mathf.Deg2Rad)
        );
        SetVelocity(startDirection);

    }

    private void SetVelocity(Vector2 startDirection)
    {
        ball.RigidBody.velocity = startDirection.normalized * speed;
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
        ball.RigidBody.velocity = ball.RigidBody.velocity.normalized * speed;
        //SpeedIncreasePrint();
    }

    private void ChangeDirectionRandomly()
    {
        var velocity = ball.RigidBody.velocity.normalized;
        if (Mathf.Abs(velocity.x) < 0.2f)
        {
            velocity.x = Random.Range(-2f, 2f);
        }
        if (Mathf.Abs(velocity.y) < 0.2f)
        {
            velocity.y = Random.Range(-2f, 2f);
        }
        ball.RigidBody.velocity = velocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Opponent"))
        {
            AudioManager.Instance.PlayPaddleHit();
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            GameManager.Instance.pointScoring.ScorePointForPlayer(ball);
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            GameManager.Instance.pointScoring.ScorePointForOpponent(ball);
        }
        if (collision.gameObject.CompareTag("TopWall"))
        {
            ChangeDirectionRandomly();
        }
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            ChangeDirectionRandomly();
        }
    }

    public void StartMultipleBall()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(0.5f, 1f);

        if (Random.value < 0.5f)
        {
            y *= -1;
        }

        Vector2 direction = new Vector2(x, y).normalized;

        SetVelocity(direction);
    }
}
