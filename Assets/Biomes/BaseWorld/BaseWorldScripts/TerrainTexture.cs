using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTexture : MonoBehaviour
{
    public static int[,] Terrain(int[,] map)
    {   
        int terrainHeight = (int)(map.GetUpperBound(1)/2); //default height for terrain to start
        int dirtHeight = (int)(map.GetUpperBound(1)/3); //default height for dirt layer

        for (int x = 0; x < map.GetUpperBound(0); x++)
        {   
            try{
            // Terrain height
            if (x % 3 == 0 || x % 7 == 0){ //determine if a coin toss should be held
                terrainHeight = terrainHeight + (Random.Range(-1,1)*Random.Range(-1,2)) + Random.Range(0,1); //Increase or decrease the height of the top layer
            }
            for (int y = (int)(map.GetUpperBound(1)/2.5); y < terrainHeight; y++){ //add the terrain on top
                map[x,y] = 1;
            }   
            }
            finally{}

            try{
            // Dirt height
            if (x % 5 == 0 || x % 4 == 0){
                dirtHeight = dirtHeight + (Random.Range(-1,1)*Random.Range(-1,2)) + Random.Range(0,1); //Increase or decrease the height of the dirt layer
            }
            for (int y = (int)(map.GetUpperBound(1)/2.5) ; y > dirtHeight ; y--){ //change the dirt level
                map[x,y] = 1;
            }   
            for (int y = dirtHeight; y < 0; y--){ //replace any gaps below with stone
                map[x,y] = 2;
            }
            }
            finally{}

        }
        print("TerrainTexture");
        return map;
    }
}