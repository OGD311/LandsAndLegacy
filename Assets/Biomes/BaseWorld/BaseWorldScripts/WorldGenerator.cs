using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{   
    //Base
    public int MapX;
    public int MapY;
    public Tilemap Tilemap;
    public Tile[] Tiles;

    public static int[,] map;

    public List<int> heights = new List<int>();


    //Seed
    public string PlayerSeed;

    //Extras
    public bool GenBorders = true;
    public bool Desert = true;
    public bool Regen = false;
    public int BorderSize = 8;

    

    public void WorldGen(){ 
        //Initialise Seed
        SeedGenerator.GenerateSeed(PlayerSeed);


        //Basic World
        map = new int[MapX+8,MapY+8]; // Initialise new integer array

        map = BaseWorldGen.GenerateBasic(map); // Basic Dirt + Stone world

        map = TerrainTexture.Terrain(map); //Variation in height
       
        map = CaveGeneration.GenerateCaves(map); //Generate Caves above + below surface
        
        map = BaseWorldGen.GenerateGrass(map); // Add Grass Layer




        // Biome Generation

        heights = TerrainHeights.getHeights(map, heights); //Get the current heights of each column


        //Desert Biome Generation
        if (Desert == true){
            for (int i = 0; i < Random.Range(2,5); i++){
                map = DesertGeneration.GenerateDesert(map, heights); 
            }
        }

        //Border Generation
        if (GenBorders == true){
            map = BaseWorldGen.GenerateBorders(map, BorderSize); // Render Borders last
        }

        RenderUpdateWorld.RenderUpdateMap(map, Tilemap, Tiles, true);
        print("World Generated!");
    }



    void Start(){
        WorldGen();
    }

}





















    // void Update(){
    //     if (Regen == true){
    //         Regen = false;
    //         WorldGen();
    //     }
    // }


    // private (int, int) WorldSizeToMapSize(int worldSize){
    //     int mapX, mapY;
    //     switch (worldSize){
    //         case 0:
    //             mapX = 1500;
    //             mapY = 750;
    //             break;
    //         case 1:
    //             mapX = 3000;
    //             mapY = 1500;
    //             break;
    //         case 2:
    //             mapX = 6000;
    //             mapY = 3000;
    //             break;
    //         default:
    //             mapX = 1500;
    //             mapY = 750;
    //             break;
    //     }

    //     return (mapX, mapY);
    // }


