using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 Position => transform.position;

    public Rigidbody2D RigidBody { get; private set; }

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }
}
