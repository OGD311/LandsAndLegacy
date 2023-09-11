using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGeneration : MonoBehaviour
{   
    public static int[,] GenerateCaves(int[,] map, List<int> TerrainHeights){
        int x;
        int y;
        int CaveLength;

        
            for (int c = 0; c < Random.Range(35,50); c++){
                try{
                    CaveLength = Random.Range(120, 400);
                    x = Random.Range(5, map.GetUpperBound(0));

                    if (Random.Range(0,2) == 0){
                        y = Random.Range(20, (int)(map.GetUpperBound(1)/1.5));
                    }
                    else{
                        y = TerrainHeights[x];
                    }
                    

                    for (int Cl = 0; Cl < CaveLength; Cl++){
                        map[x,y] = -1;
                        map[x+1,y] = -1;
                        map[x,y+1] = -1;
                        map[x+1,y+1] = -1;



                        x = x + Random.Range(-1,2);
                        y = y + Random.Range(-1,2);

                        if ((x < 0) || (y < 0) || (x > map.GetUpperBound(0)) || (y > map.GetUpperBound(1))){
                            break;
                        }
                    }
                }
                finally{
                    print("");
                }
        }
        
        return map;
    }
}
