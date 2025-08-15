using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; // List of groups of enemies to spawn in this wave
        public int enemiesNumToSpawn; // total number of enemies to spawn in this wave
        public float spawnInterval; // interval at which enemies will spawn
        public int spawnCount; // number of enemies already spawned
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; // The number of enemies to spawn in this wave
        public int spawnCount; // The number of enemies of this type already spawned in this wave
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
