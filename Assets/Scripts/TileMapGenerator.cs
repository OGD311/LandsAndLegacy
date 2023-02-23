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

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMap();
    }

    void GenerateMap()
    {
        int stoneDepth = Random.Range(20, (mapSizeY / 3)+40);
        for (int x = 0; x < mapSizeX; x++) 
        {
            int prevStoneDepth = stoneDepth + Random.Range(-2,2);
            int grassLevel = (int)((mapSizeY-(mapSizeY/5)) + Random.Range(-2,1));
            int mudDepth = grassLevel - stoneDepth;

            for (int y = 0; y < mapSizeY; y++)
            {
                Tile tile = null;
                if (y < prevStoneDepth)
                {   
                    //Generating Ores in the stone part of the world
                    int oreGen = Random.Range(1,1000);
                    if (oreGen < 990){
                        tile = bottomTiles[0];
                    }
                    else if (oreGen >= 990 && oreGen < 994){
                        tile = bottomTiles[1];
                    }
                    else if (oreGen >= 994 && oreGen < 997){
                        tile = bottomTiles[2];
                    }  
                    else if (oreGen >= 997 && oreGen < 999){
                        tile = bottomTiles[3];
                    }  
                    else if (oreGen >= 999 && oreGen < 1001){
                        tile = bottomTiles[4];
                    }  
                }
                else if (y < grassLevel )
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
