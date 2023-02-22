using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerator : MonoBehaviour
{
    public Tile[] topTiles;
    public Tile[] middleTiles;
    public Tile[] bottomTiles;
    public int mapSizeX = 10;
    public int mapSizeY = 10;
    public int minHeight = 1;
    public int maxHeight = 5;

    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            int columnHeight = Random.Range(minHeight, maxHeight + 1);
            for (int y = 0; y < mapSizeY; y++)
            {
                Tile tile = null;
                if (y == mapSizeY - 1)
                {
                    tile = topTiles[Random.Range(0, topTiles.Length)];
                }
                else if (y == 0)
                {
                    tile = bottomTiles[Random.Range(0, bottomTiles.Length)];
                }
                else if (y >= mapSizeY - columnHeight)
                {
                    tile = middleTiles[Random.Range(0, middleTiles.Length)];
                }
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}