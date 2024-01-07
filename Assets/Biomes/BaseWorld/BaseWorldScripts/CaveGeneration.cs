using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGeneration : MonoBehaviour
{   
    public static int[,] GenerateCaves(int[,] map)
    {
        int width = map.GetUpperBound(0) + 1;
        int height = (int)((map.GetUpperBound(1) + 1)/1.6); //Keep caves in the bottom ~2/3 of the map, with a bit of overlap to change surface terrain

        for (int c = 0; c < Random.Range(80, 150); c++) //Number of caves to generate
        {
            int CaveLength = Random.Range(20, 400); // Determines the length of the cave
            int x = Random.Range(0, width); // Starting X coordinate
            int y = Random.Range(0, height); // Starting Y coordinate

            for (int Cl = 0; Cl < CaveLength; Cl++) // Generate cave
            {
                DrawSquare(map, x, y, width, height); // Call the DrawSquare function which changes blocks in a 1 block radius
                
                x += Random.Range(-1, 2);
                y += Random.Range(-1, 2);

                if (x < 0 || y < 0 || x >= width || y >= height) // Break if coordinates out of bounds (cut cave short if necessary)
                {
                    break;
                }
            }
        }

        print("Cave Generated");
        return map;
    }

    private static void DrawSquare(int[,] map, int x, int y, int width, int height)
    {
        for (int i = -1; i <= 1; i++) // Cycle nearby blocks (x coordinate) +- 1
        {
            for (int j = -1; j <= 1; j++) // Cycle nearby blocks (y coordinate) +- 1
            {
                int newX = x + i; // Combine with current x coordinate
                int newY = y + j; // Combine with current y coordinate

                if (newX >= 0 && newY >= 0 && newX < width && newY < height) // If block not outside of world boundaries
                {
                    map[newX, newY] = -1; // Update blocks
                }
            }
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CaveGeneration : MonoBehaviour
// {   
//     public static int[,] GenerateCaves(int[,] map){
//         int x;
//         int y;
//         int CaveLength;

        
//         for (int c = 0; c < Random.Range(80,150); c++){
//             try{
//                 CaveLength = Random.Range(20, 400); //Length of the cave in terms of number of blocks moved
//                 x = Random.Range(0, map.GetUpperBound(0)); // Starting X

//                 y = Random.Range(0, (int)(map.GetUpperBound(1)/1.75)); //Keep caves in the bottom ~1/2 of the map, with a bit of overlap to change surface terrain

//                 for (int Cl = 0; Cl < CaveLength; Cl++){
//                     try{
//                         map[x,y] = -1;
//                         map[x+1,y] = -1;
//                         map[x,y+1] = -1;
//                         map[x+1,y+1] = -1;
//                     }
//                     catch{}

//                     x = x + Random.Range(-1,2);
//                     y = y + Random.Range(-1,2);

//                     if ((x < 0) || (y < 0) || (x > map.GetUpperBound(0)) || (y > map.GetUpperBound(1))){
//                         break;
//                     }
//                 }
//             }
//             finally{
//                print("Cave Failed");
//             }
//         }
//         print("CaveGenerated");
//         return map;
//     }
// }
