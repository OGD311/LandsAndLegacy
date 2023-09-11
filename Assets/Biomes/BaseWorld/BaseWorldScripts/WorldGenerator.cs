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
    [SerializeField]
    public int[,] map;

    //Seed
    public string PlayerSeed;
    public int Seed;

    //Lists
    
    private List<int> TerrainHeights;


    //Extras
    public bool GenBorders = true;
    public bool Desert = true;
    public bool Regen = false;

    

    public void WorldGen(){ 
        //Initialise Seed
        Seed = SeedGenerator.GenerateSeed(PlayerSeed);
        Random.InitState(Seed);


        //Basic World
        int[,] map = new int[MapX+8,MapY+8]; // Initialise new integer array
        map = BaseWorldGen.GenerateBasic(map); // Basic Dirt + Stone world
        (map, TerrainHeights) = TerrainTexture.Terrain(map);
       
        map = CaveGeneration.GenerateCaves(map, TerrainHeights); //Generate Caves above + below surface

        map = BaseWorldGen.GenerateGrass(map); // Add Grass Layer



        //Desert Biome Generation
        if (Desert == true){
            for (int i = 0; i < Random.Range(2,5); i++){
                map = DesertGeneration.GenerateDesert(map,TerrainHeights); 
                //map = DesertGeneration.GenerateCacti(map);
            }
        }

        if (GenBorders == true){
            map = BaseWorldGen.GenerateBorders(map); // Render Borders last
        }

        RenderUpdateWorld.RenderMap(map, Tilemap, Tiles);
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