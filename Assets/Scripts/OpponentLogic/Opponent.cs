using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public int score = 0;
    public Vector2 position;

    public Opponent(int score, Vector2 position)
    {
        this.score = score;
        this.position = position;
    }
}
