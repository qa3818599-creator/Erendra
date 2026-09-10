using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Player's starting health
    private bool isDead = false; // Track player state

    private Vector3 originalSpawnPoint; // Store the player's starting position
    public int respawnHealth = 100; // Health to restore upon respawn
    public float respawnDelay = 2f; // Time in seconds before respawn

    // Property to access the isDead state
    public bool IsDead
    {
        get { return isDead; }
    }

    void Start()
    {
        // Store the player's initial position as the respawn point
        originalSpawnPoint = transform.position;
    }

    void Update()
    {
        // Check if health is zero and handle death if necessary
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isDead) // Only take damage if alive
        {
            health -= damage;
            Debug.Log("Player took damage: " + damage + ", Current health: " + health);

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true; // Set the player state to dead
        Debug.Log("Player has died");

        // Start the respawn process with a delay
        Invoke(nameof(Respawn), respawnDelay);
    }

    void Respawn()
    {
        isDead = false; // Set the player state to alive again
        health = respawnHealth; // Restore the player's health
        Debug.Log("Player has respawned with health: " + health);

        // Move the player back to their original spawn position
        transform.position = originalSpawnPoint;
    }
}
