using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGeneration : MonoBehaviour
{   
    public static int[,] GenerateForest(int[,] map, List<int> Heights)
    {
        int ForestLength = Random.Range(60, 120);
        int ForestStart = Random.Range(0, map.GetUpperBound(0) - ForestLength);
        int ForestEnd = ForestStart + ForestLength;
        int ForestDepth = Random.Range(15, 35);
        
        int y;

        try{
            for (int x = ForestStart; x < ForestEnd; x++)
            {
                y =  Heights[x]; // Initial y position

                for (int woodY = Heights[x]-ForestDepth; woodY <= y - 1; woodY++) // Cycle from bottom of Forest to surface
                {
                    if (woodY >= 0 && woodY < map.GetUpperBound(1) && map[x,woodY] != -1) // Within bounds + dont fill in caves
                    {
                        map[x, woodY] = 7; // Replace normal dirt with forest dirt
                    }
                }

                map[x,y] = 8; // Replace normal grass with forest grass

                for (int newY = y - 5; newY <= map.GetUpperBound(1); newY++) { // Clear any excess dirt, grass etc
                    if (map[x, newY] != 7 && map[x, newY] != 8 && map[x, newY] != -1) { // If the cell is not ForestDirt or Forestgrass and not already empty
                        map[x, newY] = -1;
                    }
                }

            }
        }

        catch{
            print("ForestFailed");
        }


        GenerateTrees(map, ForestStart, ForestEnd); // Generate Trees
        print("Forest Generated");
        return map;
    }


    private static int[,] GenerateTrees(int[,] map, int ForestStart, int ForestEnd){
        int numTrees = Random.Range(4, 12);

        try{  
            for (int i = 0; i < numTrees; i++){
                int x = Random.Range(ForestStart, ForestEnd+1);
                for (int y=map.GetUpperBound(1)-1; y >= 0 ; y--){
                    if ((map[x,y-1] == 8) && (map[x,y] == -1)) // Is block below ForestGrass and is air above
                    {
                        treeType(map,x,y); // Place tree

                        break;
                    }
                }
            }
        }
            
        

        catch{
            print("TreesFailed");
        }

        return map;
    }

    private static int[,] treeType(int[,] map, int startX, int startY){ //Generate type 1 tree (3 high trunk, normal leaves)
        int wood = 9; // Wood
        int leaves = Random.Range(10,12); // Leaves or fruit
        int trunkHeight = Random.Range(1,3); // 2 or 3 high trunk
        int leafStart = startY+trunkHeight+1; // Leaves start after trunkHeight trunk blocks
        int leafLayers = Random.Range(1,3); //1 or 2 layers of leaves

        for (int i = 0; i <= trunkHeight; i++){ // trunkheight wood blocks high
            map[startX,startY+i] = wood; // Place wood trunk
        }

        for (int layer = 0; layer <= leafLayers; layer++){ // Increment layer by layer
            for (int x = startX-leafLayers+layer; x <= startX+leafLayers-layer; x++){ 
                if (map[x, leafStart+layer] == -1){ // Only replace blank air not blocks
                    map[x, leafStart+layer] = leaves;
                }
            }
        }

        return map;

    }

}















//     public static int[,] GenerateForest(int[,] map){
        
//         try{
//             int ForestLength = Random.Range(25,45);
//             int ForestStart = Random.Range(0,map.GetUpperBound(0)-1);
//             int ForestEnd = ForestStart + ForestLength;
//             int ForestMid = (int)(ForestEnd/2)

//             for (int x = ForestStart; x < (ForestEnd); x++){

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
