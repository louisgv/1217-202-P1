using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Generate perlin terrain and assign it to the terrain height map
/// Restriction: Requires the GameObject to have TerrainCollider
/// </summary>

[RequireComponent(typeof(TerrainCollider))]
public class PerlinTerrain : MonoBehaviour
{
    public int resolution = 129;

    public float scale = 4.5f;

    public Vector3 worldSize = new Vector3(200, 50, 200);

    private TerrainData terrainData;

    private float xOrigin;

    private float yOrigin;

    /// <summary>
    /// Assign a random perlin origin and get terrainData
    /// </summary>
    private void Awake()
    {
        xOrigin = Random.value * resolution;

        yOrigin = Random.value * resolution;

        terrainData = GetComponent<TerrainCollider>().terrainData;
    }

    /// <summary>
    /// Initialize terrainData with worldSize, resolution and generate the height map
    /// </summary>
    private void Start()
    {
        terrainData.size = worldSize;

        terrainData.heightmapResolution = resolution;

        terrainData.SetHeights(0, 0, GenerateHeightArray(resolution));
    }


    /// <summary>
    /// Generate the height array using the specified noise function
    /// </summary>
    /// <param name="res">resolution</param>
    /// <param name="noiseFx">noise function</param>
    /// <returns>a height array</returns>
    private float[,] GenerateHeightArray(int res)
    {
        float[,] heightArray = new float[res, res];

        for (int i = 0; i < res; ++i)
        {
            for (int j = 0; j < res; ++j)
            {
                heightArray[i, j] = GetPerlinNoise(i, j, res);
            }
        }

        return heightArray;
    }

    /// <summary>
    /// Generate perlin noise at specified coordinate and resolution
    /// </summary>
    /// <param name="i">current x position</param>
    /// <param name="j">current y position</param>
    /// <param name="res">resolution</param>
    /// <returns></returns>
    private float GetPerlinNoise(int x, int y, int res)
    {
        float xCoord = xOrigin + ScaleRamp(x, res) * scale;

        float yCoord = yOrigin + ScaleRamp(y, res) * scale;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

    /// <summary>
    /// Used to scale integer grid coordinate into float postion
    /// </summary>
    /// <param name="i">grid coordinate</param>
    /// <param name="res">resolution</param>
    /// <returns>A linear step size</returns>
    private float ScaleRamp(int i, int res)
    {
        return (float)i / res;
    }
}
