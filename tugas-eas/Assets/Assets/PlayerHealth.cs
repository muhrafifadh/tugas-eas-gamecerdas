using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    

    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
        UpdateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;

        currentHealth -= damageAmount;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            // Call the function to handle player death
            PlayerDeath();
        }
    }

    public void Heal(int healAmount)
    {
        if (isDead)
            return;

        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthBar();
    }

    private void PlayerDeath()
    {
        // Implement game over logic or other actions when the player dies
        Debug.Log("Player is dead");
        // For example, you can end the game or show a game over screen
        EndGame();
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
    }

    private void EndGame()
    {
        // Implement game-ending logic, such as ending the game, displaying a game over screen, etc.
        // In this example, we quit the application
        Application.Quit();
    }
}
