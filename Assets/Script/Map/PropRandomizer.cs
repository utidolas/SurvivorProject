using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    // get prop spawn points and prop prefabs from the inspector
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;

    private void Start()
    {
        SpawnProps();
    }

    private void SpawnProps()
    {
        // loop through each spawn point and instantiate a random prop prefab
        foreach (GameObject spawnPoint in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count); // select a random prefab
            GameObject prop = Instantiate(propPrefabs[rand], spawnPoint.transform.position, Quaternion.identity);
            prop.transform.parent = spawnPoint.transform; // set the parent of the prop to the spawn point
        }
    }
}
