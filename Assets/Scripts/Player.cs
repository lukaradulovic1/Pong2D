using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    public Vector2 position;

    public Player(int score, Vector2 position)
    {
        this.score = score;
        this.position = position;
    }
    
}
