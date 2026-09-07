using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D ball;
    private GameMode GameMode { get; set; }
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
        ball.velocity = startDirection.normalized * speed;
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
        ball.velocity = ball.velocity.normalized * speed;
        SpeedIncreasePrint();
    }

    private void ChangeDirectionRandomly()
    {
        var velocity = ball.velocity.normalized;
        if (Mathf.Abs(velocity.x) < 0.2f)
        {
            velocity.x = Random.Range(-2f, 2f);
        }
        if (Mathf.Abs(velocity.y) < 0.2f)
        {
            velocity.y = Random.Range(-2f, 2f);
        }
        ball.velocity = velocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Opponent"))
        {
            AudioManager.Instance.PlayPaddleHit();
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            GameManager.Instance.ScorePointForPlayer();
            //ChangeDirectionRandomly();
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            GameManager.Instance.ScorePointForOpponent();
            //ChangeDirectionRandomly();

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
}
