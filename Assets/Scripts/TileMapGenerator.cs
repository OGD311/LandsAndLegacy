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
    public float scale = 10f;

    private Tilemap tilemap;

    void Update()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            int stoneDepth = Random.Range(10, (mapSizeY / 3)+10);
            int grassLevel = (int)((mapSizeY-(mapSizeY/3)) + Random.Range(-1,1));
            int mudDepth = grassLevel - stoneDepth;

            for (int y = 0; y < mapSizeY; y++)
            {
                Tile tile = null;
                if (y < stoneDepth)
                {
                    tile = bottomTiles[Random.Range(0, bottomTiles.Length)];
                }
                else if (y < grassLevel)
                {
                    tile = middleTiles[Random.Range(0, middleTiles.Length)];
                }
                else if (y == grassLevel)
                {
                    tile = topTiles[Random.Range(0, topTiles.Length)];
                }
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}

