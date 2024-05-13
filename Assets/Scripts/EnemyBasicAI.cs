using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour
{
    public float baseMovementSpeed = 3f;
    private Transform player; // Reference to the player's transform
    private float reactDistance = 20f;
    private float speedIncreaseFactor = 0.005f; // Factor to increase according to distance covered by player in Z
    bool hasCollided = false; // Flag to check if the enemy has already collided with the player
    private float distance; // To store the calculated distance to the player

    void Start()
    {
        player = GameObject.Find("Player").transform; // Find the player object and get its transform
    }

    void Update()
    {
        if (hasCollided) return; // If the enemy has collided, skip the Update logic

        // Calculate dynamic speed based on the player's Z position
        float dynamicSpeed = baseMovementSpeed + (player.position.z * speedIncreaseFactor);

        // Calculate the distance between the enemy and the player
        distance = Vector3.Distance(player.position, transform.position);

        // If within react distance, rotate to face the player
        if (distance < reactDistance)
        {
            // Calculate look direction
            Vector3 lookDirection = (player.position - transform.position).normalized;

            // Rotate enemy towards the normalized look direction
            transform.rotation = Quaternion.LookRotation(lookDirection);

            // Desired position of the enemy is in the direction of look direction (towards player)
            Vector3 desiredPosition = transform.position + new Vector3(lookDirection.x * dynamicSpeed * 0.5f, 0, lookDirection.z * dynamicSpeed) * Time.deltaTime;

            // Apply new position
            transform.position = desiredPosition;

        }

        // Destroy enemies if they fall behind the player by at least 3 meters
        if (transform.position.z - player.position.z < -3f)
        {
            Destroy(gameObject);
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        // Check for collision with the player
        if (collision.gameObject.tag == "Player")
        {
            hasCollided = true; // Set the collision flag
        }
    }
}
