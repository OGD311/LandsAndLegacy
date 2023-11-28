using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGeneration : MonoBehaviour
{   
    public static int[,] GenerateCaves(int[,] map){
        int x;
        int y;
        int CaveLength;

        
        for (int c = 0; c < Random.Range(80,150); c++){
            try{
                CaveLength = Random.Range(20, 400);
                x = Random.Range(0, map.GetUpperBound(0));

                y = Random.Range(0, (int)(map.GetUpperBound(1)/1.75));


                

                for (int Cl = 0; Cl < CaveLength; Cl++){
                    try{
                        map[x,y] = -1;
                        map[x+1,y] = -1;
                        map[x,y+1] = -1;
                        map[x+1,y+1] = -1;
                    }
                    catch{}

                    x = x + Random.Range(-1,2);
                    y = y + Random.Range(-1,2);

                    if ((x < 0) || (y < 0) || (x > map.GetUpperBound(0)) || (y > map.GetUpperBound(1))){
                        break;
                    }
                }
            }
            finally{
                print("Cave Failed");
            }
        }
        print("CaveGenerated");
        return map;
    }
}
