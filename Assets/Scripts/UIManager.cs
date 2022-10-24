using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] Image[] ships; 

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
        Health(GameManager.instance.health);
    }

    void Health(int health)
    {
        for (int i = 0; i < ships.Length; i++)
        {
            if(health - 1 < i) ships[i].enabled = false;
        }
    }

}
