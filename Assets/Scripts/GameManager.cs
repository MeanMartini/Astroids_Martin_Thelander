using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int health = 3;
    public int score = 0;

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void TakeDamage()
    {
        health -= 1;
        Debug.Log(health);
    }

    public void AddScore()
    {
        score += 10;
        Debug.Log(score);
    }
}
