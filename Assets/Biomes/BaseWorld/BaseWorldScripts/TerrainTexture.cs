using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTexture : MonoBehaviour
{
    public static int[,] Terrain(int[,] map)
    {   
        int prevHeight = (int)(map.GetUpperBound(1)/2);
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {   
            prevHeight = prevHeight+Random.Range(-1,1)+Random.Range(0,2);

            if (x % 3 == 0 || x % 7 == 0){
                for (int y = (int)(map.GetUpperBound(1)/2); y < prevHeight; y++){
                    map[x,y] = 1;
                    
                }
            }
            else{
                for (int y = (int)(map.GetUpperBound(1)/2); y < prevHeight; y++){
                    map[x,y] = 1;
                }
            }
        }   

        return map;
    }
}




