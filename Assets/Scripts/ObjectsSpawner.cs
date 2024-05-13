using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    public List<GameObject> enemies;
    private int spawnDistanceOffset = 13;
    private float firstSpawnZ = 0;
    private int spawnAmount = 3;
    private Transform player;
    private int lastObstacleIndex = -1; // To keep track of last spawned obstacle to not spawn two of the same in a row
    // Start is called before the first frame update
    void Start()
    {
        // Get the transform object of our player
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawns obstacles with coins or enemies
    public void SpawnObjects()
    {
        firstSpawnZ = player.position.z + 80;
        // Spawn either obstacle or enemy
        for (int i = 0; i < spawnAmount; i++)
        {
            firstSpawnZ += spawnDistanceOffset;

            // A random chance of about 60% to spawn an obstacle
            if (Random.Range(0f, 1f) <= 0.60f)
            {
                // Get random obstacle
                int randomObstacleIndex = Random.Range(0, obstacles.Count);
                GameObject newObstacle;
                if (randomObstacleIndex == lastObstacleIndex) // If same as last spawned, spawn the one right after for a bit of variety
                {
                    int newIndex = (randomObstacleIndex + 1) % obstacles.Count;
                    newObstacle = obstacles[newIndex];
                    lastObstacleIndex = newIndex;
                }
                else // If different from last spawned, just spawn it
                {
                    newObstacle = obstacles[randomObstacleIndex];
                    lastObstacleIndex = randomObstacleIndex;
                }
                Instantiate(newObstacle, new Vector3(0, -0.2f, firstSpawnZ), newObstacle.transform.rotation);
            }
            // If not an obstacle, then spawn an enemy
            else
            {
                // Get random enemy
                GameObject enemy = enemies[Random.Range(0, enemies.Count)];
                Instantiate(enemy, new Vector3(Random.Range(-4, 5), 0f, firstSpawnZ), enemy.transform.rotation);

                // Small chance (40%) to spawn a 2nd enemy (increases progressively, after 1000m it becomes 50% etc)
                if (Random.Range(0f, 1f) <= (0.40f + player.position.z / 10000))
                {
                    enemy = enemies[Random.Range(0, enemies.Count)];
                    Instantiate(enemy, new Vector3(Random.Range(-4, 5), 0f, firstSpawnZ), enemy.transform.rotation);
                    // Even smaller chance (20%) to spawn a 3rd enemy (also increases progressively)
                    if (Random.Range(0f, 1f) <= (0.20f + player.position.z / 20000))
                    {
                        enemy = enemies[Random.Range(0, enemies.Count)];
                        Instantiate(enemy, new Vector3(Random.Range(-4, 5), 0f, firstSpawnZ), enemy.transform.rotation);
                    }
                }
            }

            // Delete objects behind the player
            DeleteCreatedObjectsBehindPlayer();
        }



    }


    // Deletes obstacles/enemies out of sight
    void DeleteCreatedObjectsBehindPlayer()
    {
        // Find all objects with the "Instantiatable" tag
        GameObject[] instantiatablesArrays = GameObject.FindGameObjectsWithTag("Instantiatable");

        // Iterate through each item
        foreach (GameObject item in instantiatablesArrays)
        {
            // Delete items out of player range
            if (item.transform.position.z - player.position.z < -8f)
            {
                // Destroy the item
                Destroy(item);
            }
        }
    }
}