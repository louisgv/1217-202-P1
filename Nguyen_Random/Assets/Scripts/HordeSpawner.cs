using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSpawner : MonoBehaviour
{
    public int spawnCount = 108;

    public List<GameObject> listOfObjectPrefabs;

    public float spawnRadius = 9.0f;

    /// <summary>
    /// Repeatedly spawning objects for spawnCount times
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var randomObject = listOfObjectPrefabs[Random.Range(0, listOfObjectPrefabs.Count)];

            // Use Gaussian distribution to generate a bell curve by absolute on one axis
            Vector3 spawnPosition = transform.position + new Vector3(MathHelper.Gaussian(0, spawnRadius), 0, -MathHelper.AbsGaussian(0, spawnRadius));

            // Adjust height with terrain
            spawnPosition.y = Terrain.activeTerrain.SampleHeight(spawnPosition);

            var randomObjectInstance = Instantiate(randomObject, spawnPosition, Quaternion.identity);

            randomObjectInstance.transform.SetParent(transform);
        }
    }
}
