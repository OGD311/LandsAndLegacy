using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertGeneration : MonoBehaviour
{   

    public static int[,] GenerateDesert(int[,] map){
        
        try{
            int DesertLength = Random.Range(25,45);
            int DesertStart = Random.Range(0,map.GetUpperBound(0)-1);

            for (int x = DesertStart; x < (DesertStart+DesertLength); x++){

                for (int y = x-Random.Range(20,35); y <= x-1; y++){
                    map[x,y] = 4;
                }

            }
            
        }

        finally{
            print("Failed");
        }

        return map;
    }

    public static int[,] GenerateCacti(int[,] map){
        int NumCacti = Random.Range(2,6);

        try{
            for (int x = 0; x < map.GetUpperBound(0); x++){
                    for (int y = 0; y <= map.GetUpperBound(1); y++){

                    if ((map[x,y-1] == 4) && (map[x,y+1] == -1)){

                        for (int c = 0; c < Random.Range(2,3); c++){
                            map[x,y+c] = Random.Range(5,6);
                        }
                    }
                    }
                }

        }
        finally{
            print("");
        }
        return map;
    }

}
