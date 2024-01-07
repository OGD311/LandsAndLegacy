using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertGeneration : MonoBehaviour
{   
    public static int[,] GenerateDesert(int[,] map, List<int> Heights)
    {
        int DesertLength = Random.Range(45, 75);
        int DesertStart = Random.Range(0, map.GetUpperBound(0) - DesertLength);
        int DesertEnd = DesertStart + DesertLength;
        int DesertMid = DesertStart + (DesertLength / 2);
        int DesertDepth = Random.Range(35, 65);

        int y =  Heights[DesertStart]; // Initial y position

        try{
            for (int x = DesertStart; x < DesertEnd; x++)
            {
                // Adjust y based on whether x is before or after the midpoint
                if (x < DesertMid){
                    y += Random.Range(0, 2); // Increase y
                }

                else{
                    y -= Random.Range(0, 2); // Decrease y
                }

                if (x % 5 == 0 || x % 4 == 0){
                    DesertDepth = DesertDepth + (Random.Range(-1,1)*Random.Range(-1,2)) + Random.Range(0,1); //Increase or decrease the height of the sand layer
                }

                for (int sandY = Heights[x]-DesertDepth; sandY <= y + 1; sandY++) // Cycle from bottom of desert to surface
                {
                    if (sandY >= 0 && sandY < map.GetUpperBound(1) && map[x,sandY] != -1) // Within bounds + dont fill in caves
                    {
                        map[x, sandY] = 4;
                    }
                }

                for (int newY = y - 5; newY <= map.GetUpperBound(1); newY++) { // Clear any excess dirt, grass etc
                    if (map[x, newY] != 4 && map[x, newY] != -1) { // If the cell is not sand and not already empty
                        map[x, newY] = -1;
                    }
                }

            }
        }

        catch{
            print("DesertFailed");
        }


        GenerateCacti(map, DesertStart, DesertEnd);
        print("Desert Generated");
        return map;
    }


    private static int[,] GenerateCacti(int[,] map, int DesertStart, int DesertEnd){
        int numCacti = Random.Range(2, 8);

        try{  
            for (int i = 0; i < numCacti; i++){
                int x = Random.Range(DesertStart, DesertEnd+1);
                for (int y=map.GetUpperBound(1)-1; y >= 0 ; y--){
                    if ((map[x,y-1] == 4) && (map[x,y] == -1)) // Is block below sand and is air above
                    {
                        int cactusHeight = Random.Range(2, 4); // For cactus height of 2 or 3

                        for (int c = 0; c < cactusHeight; c++){
                            map[x, y + c] = Random.Range(5, 7); // Varied Cactus Tiles

                        }
                        break;
                    }
                }
            }
        }
            
        

        catch{
            print("CactusFailed");
        }

        return map;
    }

}















//     public static int[,] GenerateDesert(int[,] map){
        
//         try{
//             int DesertLength = Random.Range(25,45);
//             int DesertStart = Random.Range(0,map.GetUpperBound(0)-1);
//             int DesertEnd = DesertStart + DesertLength;
//             int DesertMid = (int)(DesertEnd/2)

//             for (int x = DesertStart; x < (DesertEnd); x++){

//                 for (int y = x-Random.Range(20,35); y <= x-1; y++){
//                     map[x,y] = 4;
//                 }

//             }
            
//         }
//         GenerateCacti(map);

//         finally{
//             print("Failed");
//         }

//         return map;
//     }

//     private static int[,] GenerateCacti(int[,] map){
//         int NumCacti = Random.Range(2,6);

//         try{
//             for (int x = 0; x < map.GetUpperBound(0); x++){
//                     for (int y = 0; y <= map.GetUpperBound(1); y++){

//                     if ((map[x,y-1] == 4) && (map[x,y+1] == -1)){

//                         for (int c = 0; c < Random.Range(2,3); c++){
//                             map[x,y+c] = Random.Range(5,6);
//                         }
//                     }
//                     }
//                 }

//         }
//         finally{
//             print("");
//         }
//         return map;
//     }

// }
