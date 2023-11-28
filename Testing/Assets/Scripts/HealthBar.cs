using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private float currentHealth; // Store the current health value

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        currentHealth = health;
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // Function to gradually reduce health over time
    public void DecreaseHealthOverTime(float damagePerSecond)
    {
        if (currentHealth <= 0) // Prevent health from going below zero
            return;

        currentHealth -= damagePerSecond * Time.deltaTime;
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (currentHealth <= 0) // Check if health has reached zero
        {
            // Load the game over scene
            SceneManager.LoadScene("game over");
        }
    }
}
