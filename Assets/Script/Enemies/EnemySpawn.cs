using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>(); // List of enemies to spawn
    public int currentWave; 
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>(); // List to hold spawned enemies and clear it after each wave

    public Transform spawnLocation; // Reference to the Transform component of the EnemySpawn GameObject
    public int waveDuration;  // Duration of the wave in seconds
    private float waveTimer; // Timer to track the duration of the wave
    private float spawnInterval; // Interval for spawning enemies
    private float spawnTimer; // Timer to track the spawning of enemies

    private void Start()
    {
        GenerateWave(); // Generate the first wave of enemies at the start
    }

    private void FixedUpdate()
    {
        if(spawnTimer <= 0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity); // Spawn the first enemy in the list at the spawn location
                enemiesToSpawn.RemoveAt(0); // Remove the spawned enemy from the list
                spawnTimer = spawnInterval; // Reset the spawn timer to the spawn interval
            }
            else
            {
                waveTimer = 0; // Reset the wave timer if there are no enemies left to spawn
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime; // Decrease the spawn timer by the fixed delta time
            waveTimer -= Time.fixedDeltaTime; // Decrease the wave timer by the fixed delta time
        }
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10; // Calculation for wave value based on current wave
        GenerateEnemeies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; // Fixed time interval for spawning enemies
        waveTimer = waveDuration; // Initialize the wave timer to the duration of the wave
    }

    public void GenerateEnemeies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>(); // List to hold spawned enemies
        while (waveValue > 0)
        {
            int randomEnemyID = Random.Range(0, enemies.Count); // Randomly select an enemy from the list
            int randomEnemyCost = enemies[randomEnemyID].cost; // Get the cost of the randomly selected enemy

            if (waveValue-randomEnemyCost>=0) // Check if can afford it
            {
                generatedEnemies.Add(enemies[randomEnemyID].enemyPrefab); // Add the enemy prefab to the list of generated enemies
                waveValue -= randomEnemyCost; // Deduct the cost from the wave value
            }
            else if (true)
            {
                break; // If can't afford, break the loop
            }

        }
        enemiesToSpawn.Clear(); // Clear the list of spawned enemies
        enemiesToSpawn = generatedEnemies; // Assign the generated enemies to the list of spawned enemies
    }

}

[System.Serializable]
public class Enemy 
{ 
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public int cost; // 'Cost' to spawn the enemy
}
