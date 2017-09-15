using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public int spawnCount = 45;

    public List<GameObject> listOfObjectPrefabs;

    public float spawnRadius = 45;

    /// <summary>
    /// Repeatedly spawning objects for spawnCount times
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var randomObject = listOfObjectPrefabs[Random.Range(0, listOfObjectPrefabs.Count)];

            // Use Gaussian distribution to generate a bell curve by absolute on one axis
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1.0f, 1.0f) * spawnRadius, 0, Random.Range(-1.0f, 1.0f) * spawnRadius);

            // Adjust height with terrain
            spawnPosition.y = Terrain.activeTerrain.SampleHeight(spawnPosition);

            // Spawn an object with random rotation
            var randomObjectInstance = Instantiate(randomObject, spawnPosition, Quaternion.Euler(Random.Range(0, 360), 0, 0));
            
            randomObjectInstance.transform.SetParent(transform);
        }
    }
}
