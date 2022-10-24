using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lastScoreText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button startButton;

    [SerializeField] Image[] ships;  

    private void Start()
    {
        startButton.onClick.AddListener(Play);
        Pause();
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
        lastScoreText.text = "Last score: " + GameManager.instance.score;
        Health(GameManager.instance.health);

        if(GameManager.instance.health <= 0)
        {
            Pause();
        }        
    }

    

    void Health(int health)
    {
        for (int i = 0; i < ships.Length; i++)
        {
            if(health - 1 < i) ships[i].enabled = false;
        }
    }

    void Pause()
    {        
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    void Play()
    {        
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

}
