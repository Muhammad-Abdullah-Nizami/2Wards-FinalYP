using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text Highscore;
    public float scorePerSecond = 10f;

    private float score = 0f;
    private float highScoreCount = 0f;
    
    //variables to stop score upon gameover and display score on ui
    public static bool GameHasEnded = false;
    public static float CountedScoretoDisplay = 0;
    public static float HighscoretoDisplay = 0;



    void Start()
    {
        // Load the high score from PlayerPrefs
        LoadHighScore();
    }

    void Update()
    {
        IncrementScore(Time.deltaTime * scorePerSecond);
        UpdateScoreUI();
    }

    void IncrementScore(float amount)
    {
        if (!GameHasEnded)
        {
            if (Time.timeScale > 0)
            {
                score += amount;

                if (score > highScoreCount)
                {
                    highScoreCount = score;

                    // Save the high score to PlayerPrefs
                    SaveHighScore();

                    // Update the Highscore UI Text element
                    if (Highscore != null)
                    {
                        Highscore.text = "High Score: " + Mathf.RoundToInt(highScoreCount);
                        
                    }
                }
            }
        }
            
    }

    void UpdateScoreUI()
    {
        // Update the UI Text element with the current score
        if (scoreText != null)
        {
            scoreText.text = " " + Mathf.RoundToInt(score);
            CountedScoretoDisplay = Mathf.RoundToInt(score);

        }
        // StopGame();
    }

    void SaveHighScore()
    {
        // Save the high score to PlayerPrefs
        PlayerPrefs.SetFloat("HighScore", highScoreCount);
        
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        // Load the high score from PlayerPrefs
        highScoreCount = PlayerPrefs.GetFloat("HighScore", 0f);

        // Update the Highscore UI Text element
        if (Highscore != null)
        {
            Highscore.text = "High Score: " + Mathf.RoundToInt(highScoreCount);
            HighscoretoDisplay = Mathf.RoundToInt(highScoreCount);
        }
    }

    // Call this method when the player collides with the obstacle
    public void StopGame()
    {
        Time.timeScale = 0f; // Pause the scoring
        UpdateScoreUI();
    }

    // Call this method when the player wants to reset the high score
    public void ResetHighScore()
    {
        highScoreCount = 0f;
        SaveHighScore();
        LoadHighScore();
        Time.timeScale = 1f; // Resume the scoring
    }
}
