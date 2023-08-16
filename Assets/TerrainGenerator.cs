using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 100;
    public int height = 50;
    public GameObject[] tilePrefabs;
    public Transform terrainParent;

    void Start()
    {
        GenerateTerrain();
    }

float perlinScale = 0.1f;

void GenerateTerrain()
{
    for (int x = 0; x < width; x++)
    {
        float perlinValue = Mathf.PerlinNoise(x * perlinScale, 0);
        int terrainHeight = Mathf.FloorToInt(perlinValue * height);

        for (int y = 0; y < height; y++)
        {
            GameObject selectedTilePrefab = GetRandomTilePrefab();
            Vector3 tilePosition = new Vector3(x, y, 0);

            if (y <= terrainHeight)
            {
                GameObject tile = Instantiate(selectedTilePrefab, tilePosition, Quaternion.identity);
                tile.transform.SetParent(terrainParent);
            }
        }
    }
}

    GameObject GetRandomTilePrefab()
    {
        int randomIndex = Random.Range(0, tilePrefabs.Length);
        return tilePrefabs[randomIndex];
    }
}
