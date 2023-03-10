using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerator : MonoBehaviour
{
    public Tile[] topTiles;
    public Tile[] middleTiles;
    public Tile[] bottomTiles;
    public int mapSizeX = 100;
    public int mapSizeY = 100;
    public int WalkMin = 3;

    private Tilemap tilemap;

    void Update()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMap();
    }

    void GenerateMap()
    {   
        int WalkNo = 0;
        int stoneDepth = Random.Range((mapSizeY/3), (mapSizeY/2)-10);
        int prevGrassLevel = 0;
        int grassLevel = (int)((mapSizeY-(mapSizeY/5)));

        for (int x = 0; x < mapSizeX; x++) 
        {
            int prevStoneDepth = stoneDepth + Random.Range(-4,4);
            
            int mudDepth = grassLevel - prevStoneDepth;
            if (mudDepth > (mapSizeY/3)){
                mudDepth = (int)(mapSizeY/3);
            }

            if (prevStoneDepth > (mapSizeY/2)){
                prevStoneDepth = (int)(mapSizeY/2)-10;
            }
            if ((WalkNo % WalkMin) == 0){
                int nextmove = Random.Range(0,100);
                if (nextmove < 33){
                    grassLevel -- ;
                }
                else if (nextmove > 33 && nextmove < 66){
                    grassLevel ++;
                }
                else{
                    grassLevel = prevGrassLevel;
                }

                if (grassLevel > mapSizeY){
                    mapSizeY = (mapSizeY+grassLevel);
                }
            }
                WalkNo ++;
            for (int y = 0; y < mapSizeY; y++)
            {
                Tile tile = null;
                if (y < prevStoneDepth)
                {   
                    int oreGen = Random.Range(1,1000);
                    if (oreGen < 990){
                        tile = bottomTiles[0];
                    }
                    else if (oreGen >= 990 && oreGen < 994){
                        tile = bottomTiles[1];
                    }
                     //Random.Range(0, bottomTiles.Length)
                    else if (oreGen >= 994 && oreGen < 997){
                        tile = bottomTiles[2];
                    }  
                    else if (oreGen >= 997 && oreGen < 999){
                        tile = bottomTiles[3];
                    }  
                    else if (oreGen >= 999 && oreGen <= 1000){
                        tile = bottomTiles[4];
                    }  
                }
                else if (y < grassLevel )
                {   
                    tile = middleTiles[0];
                }
                else if (y == grassLevel)
                {   
                    tile = topTiles[0];            
                }
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                
            }
            prevGrassLevel = grassLevel;
        }
    }
}
