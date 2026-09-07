using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 position;

    public Rigidbody2D ballRigidBody;
    public Ball(Vector2 position)
    {
        this.position = position;
    }
}
