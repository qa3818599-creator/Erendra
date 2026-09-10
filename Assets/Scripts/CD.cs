using UnityEngine;

public class CD : MonoBehaviour
{
    public int health = 35; // Monster's health
    public float clickDamageRange = 3f; // Range within which the player can click to deal damage

    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player by tag to determine distance when clicked
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnMouseDown()
    {
        // Check the distance between the player and the monster
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= clickDamageRange)
        {
            TakeDamage(35); // Example damage value from the player's click
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Monster took damage: " + damage + ", Current health: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death animation or effects here if needed
        Debug.Log("Monster has died");
        Destroy(gameObject); // Destroys the monster GameObject
    }
}