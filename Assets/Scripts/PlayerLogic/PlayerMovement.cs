using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerPaddle;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerPaddle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerPaddle.MovePosition(playerPaddle.position + Vector2.up * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerPaddle.MovePosition(playerPaddle.position + Vector2.down * speed * Time.fixedDeltaTime);
        }
        else 
        {
            playerPaddle.velocity = Vector2.zero;
        }

    }
}
