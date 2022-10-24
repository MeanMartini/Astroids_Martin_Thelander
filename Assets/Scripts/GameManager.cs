using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public int health = 3, score = 0;

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
    }

    public void AddScore()
    {
        score += 10;        
    }
    
}
