using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{   
    //Base
    public int MapX; // X Coordinate    
    public int MapY; // Y Coordinate
    public Tilemap Tilemap;

    public Tile[] Tiles; //Tiles used to represent different blocks
    public static Tile[] WorldTiles; // Static Version of Tiles so the same can be used across multiple files

    public static int[,] map;

    public List<int> heights = new List<int>();


    //World Details
    public string WorldName;
    public string PlayerSeed;
    public int WorldSize;

    //Extras
    public int BorderSize = 8;

    

    public void WorldGen(){ 
        //Initialise Seed
        SeedGenerator.GenerateSeed(PlayerSeed);


        //Basic World
        map = new int[MapX+8,MapY+8]; // Initialise new integer array

        map = BaseWorldGen.GenerateBasic(map); // Basic Dirt + Stone world

        map = TerrainTexture.Terrain(map); //Variation in height
       
        map = CaveGeneration.GenerateCaves(map, MapX); //Generate Caves above + below surface
        
        map = BaseWorldGen.GenerateGrass(map); // Add Grass Layer




        // Biome Generation
        heights = TerrainHeights.getHeights(map, heights); //Get the current heights of each column


            //Desert Biome Generation
            for (int i = 0; i < Random.Range(3,6); i++){
                map = DesertGeneration.GenerateDesert(map, heights); 
            }

            //Forest Biome Generation
            for (int i = 0; i < Random.Range(3,6); i++){
                map = ForestGeneration.GenerateForest(map, heights); 
            }


        //Border Generation
        map = BaseWorldGen.GenerateBorders(map, BorderSize); // Render Borders 


        RenderUpdateWorld.RenderMap(map, Tilemap, Tiles);
        print("World Generated!");
    }
    
    void Start(){
        WorldTiles = Tiles; //Initiate WorldTiles Static
        PlayerSeed = PlayerPrefs.GetString("playerSeed");
        WorldName = PlayerPrefs.GetString("worldName");
        WorldSize = PlayerPrefs.GetInt("worldSize");
        (MapX, MapY) = WorldSizeToMapSize(WorldSize);
        print((MapX, MapY));
        WorldGen();
    }




    private (int, int) WorldSizeToMapSize(int worldSize){
        int mapX;
        int mapY;

        switch (worldSize){
            case 0:
                mapX = 1000;
                mapY = 300;
                break;
            case 1:
                mapX = 1500;
                mapY = 400;
                break;
            case 2:
                mapX = 2000;
                mapY = 500;
                break;
            default:
                mapX = 1500;
                mapY = 400;
                break;
        }

        return (mapX, mapY);
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


