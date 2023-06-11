using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackCooldown = 1f;
    public float attackRange = 2f;

    private bool canAttack = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!canAttack)
        {
            return; // Attack on cooldown, do nothing
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if player is within attack range
            float distance = Vector3.Distance(transform.position, collision.transform.position);
            if (distance <= attackRange)
            {
                // Apply damage to the player
                var healthComponent = collision.gameObject.GetComponent<CharacterStats>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(attackDamage);
                }

                // Start cooldown timer
                canAttack = false;
                Invoke(nameof(ResetAttack), attackCooldown);
            }
        }
    }
     private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canAttack = false;
            attackCooldown = 0f; // Reset the damage timer when the player exits collision
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
