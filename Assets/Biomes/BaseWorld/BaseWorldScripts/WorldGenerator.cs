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

    public int[,] map;

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
        int[,] map = new int[MapX+8,MapY+8]; // Initialise new integer array

        map = BaseWorldGen.GenerateBasic(map); // Basic Dirt + Stone world

        map = TerrainTexture.Terrain(map); //Variation in height
       
        map = CaveGeneration.GenerateCaves(map); //Generate Caves above + below surface

        heights = TerrainHeights.getHeights(map, heights);

        map = BaseWorldGen.GenerateGrass(map); // Add Grass Layer

        
        

        //Desert Biome Generation
        if (Desert == true){
            for (int i = 0; i < Random.Range(2,5); i++){
                //map = DesertGeneration.GenerateDesert(map); 
                //map = DesertGeneration.GenerateCacti(map);
            }
        }

        //Border Generation
        if (GenBorders == true){
            map = BaseWorldGen.GenerateBorders(map, BorderSize); // Render Borders last
        }

        RenderUpdateWorld.RenderMap(map, Tilemap, Tiles);
        print("World Generated!");
    }



    void Start(){
        WorldGen();
    }

    void Update(){
        
        if (Regen == true){
            Regen = false;
            WorldGen();
        }
    }
}


// if (worldSize == 1){
//             mapSizeX = 1000;
//             mapSizeY = 200;
//         }
//         else if (worldSize == 2){
//             mapSizeX = 2500;
//             mapSizeY = 300;
//         }

//         else if (worldSize == 3){
//             mapSizeX = 5000;
//             mapSizeY = 500;
//         }