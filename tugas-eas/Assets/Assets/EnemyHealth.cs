using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            // Call the function to handle enemy death
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        // Implement actions when the enemy dies
        Debug.Log("Enemy is dead");
        // For example, you can play death animation, spawn particle effects, give player points, etc.

        // Remove the enemy from the game
        Destroy(gameObject);
    }
}
