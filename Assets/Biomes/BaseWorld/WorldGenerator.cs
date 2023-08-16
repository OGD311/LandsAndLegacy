using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{   

    public int MapX;
    public int MapY;

    public Tilemap Tilemap;
    public Tile[] Tiles;

    [SerializeField]
    public int[,] map;

    // public static int[,] GenMap(int MapX, int MapY){
    //     int[,] map = new int[MapX,MapY];

    //     for (int x = 0; x < MapX; x++){
    //         for (int y = 0; y < MapY; y++){
    //             map[x,y] = -1;
    //         }
    //     }
    //     return map;
    // }

    void Start()
    {   
        //Basic World
        int[,] map = new int[MapX,MapY]; // Initialise new integer array
        map = BaseWorldGen.GenerateBasic(map, Tilemap, Tiles); // Basic Dirt + Stone world
        map = BaseWorldGen.GenerateGrass(map, Tilemap, Tiles); // Add Grass Layer



        //Desert Biome Generation
        map = DesertGeneration.GenerateDesert(((int)(MapY/2)),MapX,map); 



        map = BaseWorldGen.GenerateBorders(map, Tilemap, Tiles); // Render Borders last
        RenderUpdateWorld.RenderMap(map, Tilemap, Tiles);
    }
}
