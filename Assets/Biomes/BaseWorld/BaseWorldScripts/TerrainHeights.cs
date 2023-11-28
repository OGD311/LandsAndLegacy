using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHeights : MonoBehaviour
{   
    public static List<int> getHeights(int[,] map, List<int> heights){
        for (int x=0; x < map.GetUpperBound(0); x++){
            for (int y=0; y < map.GetUpperBound(1); y++){
                if (map[x,y] == -1){
                    heights.Add(y);
                }
            }
        }

        return heights;
    }
}
