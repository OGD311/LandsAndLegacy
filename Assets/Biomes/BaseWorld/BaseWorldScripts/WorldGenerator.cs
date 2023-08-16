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

    //Generate borders?
    public bool GenBorders = true;
    public bool Regen = false;


    public void WorldGen(){   
        //Basic World
        int[,] map = new int[MapX+8,MapY+8]; // Initialise new integer array
        map = BaseWorldGen.GenerateBasic(map); // Basic Dirt + Stone world
        map = TerrainTexture.Terrain(map);
        map = BaseWorldGen.GenerateGrass(map); // Add Grass Layer



        //Desert Biome Generation
        //map = DesertGeneration.GenerateDesert(((int)(MapY/2)),MapX,map); 


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
