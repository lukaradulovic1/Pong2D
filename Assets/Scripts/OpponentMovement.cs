using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    Rigidbody2D opponentPaddle;
    public float speed = 3f;
    public Rigidbody2D ball;
    public float reactionDelay = 0.1f;
    private float timer = 0f;
    private float targetY;
    // Start is called before the first frame update
    void Start()
    {
        opponentPaddle = GetComponent<Rigidbody2D>();
        float verticalDirection = Random.value < 0.5f ? -1f : 1f;

        Vector2 opponentsStartingDirection = new Vector2(0, verticalDirection);

        if (opponentPaddle != null)
        {
            opponentPaddle.velocity = opponentsStartingDirection * speed;
        }
        StartCoroutine(ReactionLoop());
    }

    private void Update()
    {
        float newY = Mathf.MoveTowards(opponentPaddle.position.y, targetY, speed * Time.deltaTime);
        opponentPaddle.position = new Vector2(opponentPaddle.position.x, newY);
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        if (timer <= 0f)
        {
            timer = reactionDelay;
            targetY = ball.position.y; // ili PredictBallY(...)
        }

        float step = speed * Time.fixedDeltaTime;
        Vector2 targetPosition = new Vector2(opponentPaddle.position.x, targetY);

        opponentPaddle.MovePosition(
            Vector2.MoveTowards(opponentPaddle.position, targetPosition, step)
        );
    }


    IEnumerator ReactionLoop()
    {
        while (true)
        {
            targetY = ball.position.y;
            yield return new WaitForSeconds(reactionDelay);
        }
    }
}
