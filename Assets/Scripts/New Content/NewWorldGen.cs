using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

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
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 0; y < map.GetUpperBound(1); y++){
                map[x,y] = -1;
            }
        }

        return map;

    }

    public static void GenerateBasicTerrain(int[,] map, Tilemap tilemap, Tile[] tiles){
    int baseheight = map.GetUpperBound(1) - ((int)(map.GetUpperBound(1) / 10));

    for (int x = 0; x < map.GetUpperBound(0); x++){
        float ranx = Random.value;
        float rany = Random.value;
        float terrain = Mathf.PerlinNoise(ranx, rany);
        int mapheight = baseheight + (int)(terrain * 10);

        for (int y = 0; y < mapheight + 1; y++){
            map[x, y] = 1;
        }
    }
}



    //Rendering the map at start
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

    //Updates only tiles that have changed
    public static void UpdateMap(int[,] map, Tilemap tilemap, Tile[] tiles) //Takes in our map and tilemap, setting  tiles where needed
        {
        Tile tile = null;
        for (int x = 0; x < map.GetUpperBound(0)+1; x++)
        {
            for (int y = 0; y < map.GetUpperBound(1)+1; y++)
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
        ulong Gameseed = GameObject.Find("Landscape (1)").GetComponent<SeedGenerator>().seed;
        Random.InitState((int) Gameseed);

        world = GenerateArray(worldSize);
        GenerateBasicTerrain(world, Tilemap, WorldTiles);
        RenderMap(world, Tilemap, WorldTiles);
            
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
