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
    public bool paused;

    [SerializeField] Image[] healthIcons;  

    public static UIManager instance { get; private set; }      

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

        startButton.onClick.AddListener(Play);
        Pause();
    }

    private void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
        lastScoreText.text = "Last score: " + GameManager.instance.score;
        DispHealth(GameManager.instance.health);

        if(GameManager.instance.health == 0)
        {
            Pause();
        }        
    }

    

    void DispHealth(int health)
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (health - 1 < i) healthIcons[i].enabled = false;
            else healthIcons[i].enabled = true;
        }
    }

    void Pause()
    {        
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;
    }

    void Play()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;

        GameManager.instance.ResetScene();        
    }

}
