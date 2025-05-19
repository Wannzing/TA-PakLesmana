using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI endHighScore;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finalTimeText;
    private float elapsedTime = 0f;


    private float maxHeight = 0f;
    private int highScore = 0;
    private string highScoreKey;

    void Start()
    {
        // Create a unique key for each level based on the scene name
        string levelName = SceneManager.GetActiveScene().name;
        highScoreKey = "HighScore_" + levelName;

        // Load high score for this level
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = "Best: " + highScore;
        
    }

    void Update()
    {
        if (player == null) return;

        maxHeight = Mathf.Max(maxHeight, player.position.y);
        int currentScore = Mathf.FloorToInt(maxHeight);
        scoreText.text = "Score: " + currentScore;
        finalScore.text = "Score: " + currentScore;
        endHighScore.text = "High Score: " + highScore;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(highScoreKey, highScore);
            highScoreText.text = "High Score: " + highScore;
        }

        elapsedTime += Time.deltaTime;
        

        // Format the time as HH:MM:SS
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", 
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        TimeSpan finalTimeSpan = TimeSpan.FromSeconds(elapsedTime);
        finalTimeText.text = string.Format("{0:00}:{1:00}:{2:00}",
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);


    }
}
