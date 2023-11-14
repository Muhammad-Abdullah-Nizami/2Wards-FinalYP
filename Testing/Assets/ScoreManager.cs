using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; 
    public float scorePerSecond = 10f; // Adjust this value based on your desired scoring rate

    private float score = 0f;

    // Update is called once per frame
    void Update()
    {
        IncrementScore(Time.deltaTime * scorePerSecond);
        UpdateScoreUI();
    }
     
    void IncrementScore(float amount)
    {
        score += amount;
    }

    void UpdateScoreUI()
    {
        // Update the UI Text element with the current score
        if (scoreText != null) // Fixed variable reference here
        {
            scoreText.text = "Score: " + Mathf.RoundToInt(score);
        }
    }
}
