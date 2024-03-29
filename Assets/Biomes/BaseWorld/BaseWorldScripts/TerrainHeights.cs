using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHeights : MonoBehaviour
{   
    public static List<int> getHeights(int[,] map, List<int> heights){
        for (int x=0; x < map.GetUpperBound(0); x++){
            for (int y=map.GetUpperBound(1)-1; y >= 0 ; y--){ // Cycle from top to bottom
               
                if (map[x,y] != -1){
                    heights.Add(y); // Add height to list
                    break;
                }
            }
        }

        return heights;
    }
}
