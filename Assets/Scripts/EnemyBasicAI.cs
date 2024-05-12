using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour
{
    public float baseMovementSpeed = 10f; // Base speed of the enemy (increases progressively for difficulty)
    private Rigidbody enemyRb;
    private Transform player;
    private float reactDistance = 20f;
    private float speedIncreaseFactor = 0.01f; // Factor to increase according to distance covered by player in Z

    bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Don't move towards player if the player is dead (enemy successfully collided with player)
        if (hasCollided) return;

        // Distance from player
        float distance = Vector3.Distance(player.position, transform.position);

        // Calculate dynamic movement speed based on player's Z position
        float dynamicSpeed = baseMovementSpeed + (player.position.z * speedIncreaseFactor);

        // Player position
        Vector3 targetPosition = player.position;

        Vector3 lookDirection = (targetPosition - transform.position).normalized;

        // Rotate enemy to face the player
        transform.rotation = Quaternion.LookRotation(lookDirection);

        // When in range, attack at full dynamic speed, otherwise follow slowly
        if (distance <= reactDistance)
        {
            enemyRb.AddForce(lookDirection * dynamicSpeed);
        }
        else
        {
            enemyRb.AddForce(lookDirection * dynamicSpeed * 0.2f);
        }

        // Destroy enemies if they fall behind the player by at least 3 meters
        if (transform.position.z - player.position.z < -3f)
        {
            Destroy(gameObject);
        }
    }

    // Stop moving on collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasCollided = true;
        }
    }
}
