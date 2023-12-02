using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private actualscript actualScriptInstance;


    void Start()
    {
        GameObject actualScriptObject = GameObject.Find("astronoutTPOSE");

        // Check if the GameObject was found
        if (actualScriptObject != null)
        {
            // Try to get the ActualScript component from the found GameObject
            actualScriptInstance = actualScriptObject.GetComponent<actualscript>();

            // Check if the component was found
            if (actualScriptInstance == null)
            {
                Debug.LogError("ActualScript component not found on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject with ActualScript not found.");
        }

        MaxHealth();
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(DecreaseHealth());
    }

    public void MaxHealth()
    {
        currentHealth = maxHealth;
    }

    IEnumerator DecreaseHealth()
    {
        while (true)
        {
            TakeDamage(2);
            yield return new WaitForSeconds(1f);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            actualScriptInstance._velocity = new Vector3(0, 0, 0);
            Invoke("Loadgameover", 1f);

        }
    }

    void Loadgameover()
    {
        actualScriptInstance._velocity = new Vector3(0, 0, 0);
        SceneManager.LoadScene("game over");
    }
}
