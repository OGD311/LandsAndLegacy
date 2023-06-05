using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewWorldGen : MonoBehaviour
{



    public static int[,] GenerateArray(int worldSize) {

        //world size options:
        int mapSizeX = 0;
        int mapSizeY = 0;


        if (worldSize == 1){
            mapSizeX = 1000;
            mapSizeY = 200;
        }
        else if (worldSize == 2){
            mapSizeX = 2500;
            mapSizeY = 300;
        }

        else if (worldSize == 3){
            mapSizeX = 5000;
            mapSizeY = 500;
        }

        //generate tilemap
        int[,] map = new int[mapSizeX, mapSizeY];
        return map;

    }


    public static void RenderMap(int[,] map, Tilemap tilemap, Tile[] tiles)
        {
            //Clear the map (ensures we dont overlap)
            tilemap.ClearAllTiles();
        
            Tile tile = null;
            //Loop through the width of the map
            for (int x = 0; x < map.GetUpperBound(0) ; x++)
            {
                //Loop through the height of the map
                for (int y = 0; y < map.GetUpperBound(1); y++)
                {

                    if (map[x, y] == -1)
                    {
                        tile = null;
                    }
                    else{
                        tile = tiles[((int) map[x,y])];

                        
                    }
                    tilemap.SetTile(new Vector3Int(x,y,0), tile);
                }
            }

        }

    // Start is called before the first frame update
    public Tile[] WorldTiles;
    public Tilemap Tilemap;
    public int[,] world;

    public int worldSize;


    void Start()
    {
        world = GenerateArray(worldSize);
        RenderMap(world, Tilemap, WorldTiles);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
