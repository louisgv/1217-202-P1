using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianSpawner : MonoBehaviour
{
    public int spawnCount = 9;
        
    public List<GameObject> listOfObjectPrefabs;

    public float distanceBetweenObject = 9f;

    public float horizontalVariation = 3.6f;

    public float meanScale = 2.0f;

    public float limitScale = 5.0f;

    /// <summary>
    /// Repeatedly spawning objects for spawnCount times
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var randomObject = listOfObjectPrefabs[Random.Range(0, listOfObjectPrefabs.Count)];

            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1.0f,1.0f) * horizontalVariation, 0, i * distanceBetweenObject);

            // Adjust height with terrain
            spawnPosition.y = Terrain.activeTerrain.SampleHeight(spawnPosition);

            var randomObjectInstance = Instantiate(randomObject, spawnPosition, Quaternion.identity);

            // Scale the object only positive so it won't mirror
            randomObjectInstance.transform.localScale += Vector3.up * MathHelper.AbsGaussian(meanScale, limitScale);

            randomObjectInstance.transform.SetParent(transform);
        }
    }
}
