using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highScoreText;

    private float maxHeight = 0f;
    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best: " + highScore;
    }

    void Update()
    {
        if (player == null) return;

        // Update current height-based score
        maxHeight = Mathf.Max(maxHeight, player.position.y);
        int currentScore = Mathf.FloorToInt(maxHeight);
        scoreText.text = "Score: " + currentScore;

        // Save new high score if beaten
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "Best: " + highScore;
        }
    }
}
