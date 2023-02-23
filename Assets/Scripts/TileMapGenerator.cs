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
            int prevStoneDepth = stoneDepth + Random.Range(-4,4);
            int grassLevel = (int)((mapSizeY-(mapSizeY/3)) + Random.Range(-2,2));
            int mudDepth = grassLevel - stoneDepth;

            for (int y = 0; y < mapSizeY; y++)
            {
                Tile tile = null;
                if (y < prevStoneDepth)
                {   
                    int oreGen = Random.Range(1,100);
                    if (oreGen < 90){
                        tile = bottomTiles[0];
                    }
                    else if (oreGen >= 90 && oreGen < 94){
                        tile = bottomTiles[1];
                    }
                     //Random.Range(0, bottomTiles.Length)
                    else if (oreGen >= 94 && oreGen < 97){
                        tile = bottomTiles[2];
                    }  
                    else if (oreGen >= 97 && oreGen < 99){
                        tile = bottomTiles[3];
                    }  
                    else if (oreGen >= 99 && oreGen < 101){
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
