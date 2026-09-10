using UnityEngine;

public class TrashMonster : MonoBehaviour
{
    public int health = 100;
    public int damage = 20;
    public float attackRange = 1.5f;
    public float moveSpeed = 2f;
    public float wanderRadius = 3f;
    public float changeDirectionInterval = 2f;
    public float chaseRange = 5f;
    public float clickDamageRange = 3f;
    public float attackCooldown = 2f;

    private Vector3 originalPosition;
    private Vector3 movementDirection;
    private float timeSinceDirectionChange = 0f;
    private float timeSinceLastAttack = 0f;
    private Transform player;
    private Rigidbody rb; // Use Rigidbody for smoother physics-based movement
    private PlayerHealth playerHealth; // Reference to PlayerHealth

    void Start()
    {
        originalPosition = transform.position;
        ChooseRandomDirection();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
        rb = GetComponent<Rigidbody>(); // Ensure a Rigidbody is attached for movement
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            MoveTowardsPlayer();

            if (distanceToPlayer <= attackRange && timeSinceLastAttack >= attackCooldown)
            {
                Attack();
                timeSinceLastAttack = 0f;
            }
        }
        else
        {
            Wander();
            timeSinceDirectionChange += Time.deltaTime;

            if (timeSinceDirectionChange >= changeDirectionInterval)
            {
                ChooseRandomDirection();
                timeSinceDirectionChange = 0f;
            }
        }
    }

    void Wander()
    {
        Vector3 newPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(originalPosition, newPosition) > wanderRadius)
        {
            ChooseRandomDirection();
        }
        else
        {
            rb.MovePosition(newPosition);
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        rb.MovePosition(transform.position + directionToPlayer * moveSpeed * Time.deltaTime);
    }

    void ChooseRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        movementDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    void Attack()
    {
        if (playerHealth != null && !playerHealth.IsDead) // Check if the player is alive before attacking
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Monster attacked player for " + damage + " damage.");
        }
    }

    void OnMouseDown()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= clickDamageRange)
        {
            TakeDamage(35);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth != null && timeSinceLastAttack >= attackCooldown && !playerHealth.IsDead)
            {
                playerHealth.TakeDamage(damage);
                timeSinceLastAttack = 0f;
            }
        }
    }
}
