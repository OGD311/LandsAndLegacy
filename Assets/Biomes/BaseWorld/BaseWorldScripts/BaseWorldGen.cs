using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWorldGen : MonoBehaviour {

    public static int[,] GenerateBasic(int[,] map){ //Generate a basic world with no detail
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 0; y < map.GetUpperBound(1); y++){

                if (y < (int)(map.GetUpperBound(1)/3)){ //bottom third of the world should be stone
                    map[x,y] = 2; //Place stone tiles
                }

                else if (y < (int)(map.GetUpperBound(1)/2.5)){ // bottom 2/5ths of the world should be dirt
                    map[x,y] = 1; //Place dirt tiles
                }

                else{
                    map[x,y] = -1; //leave as air
                }
            }

        }
        print("Stone and Dirt Placed");
        return map;
    }

    public static int[,] GenerateGrass(int[,] map){ //Add grass to any dirt block with air above it
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = map.GetUpperBound(1)/5; y < map.GetUpperBound(1)-1; y++){

                if ((map[x,y-1] != -1) && (map[x,y-1] == 1) && (map[x,y+1] == -1)){ //compare current tile and ensure air above but not below
                    map[x,y] = 3; //replace dirt with grass
                }
            }
        }
        print("Grass Placed");
        return map;

    }

    public static int[,] GenerateBorders(int[,] map, int BorderSize){
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 0; y < map.GetUpperBound(1); y++){
                if (x < BorderSize || x > (map.GetUpperBound(0)-BorderSize)){ //ensure that borders only placed at correct x coordinates
                    map[x,y] = 0; //place border
                }

                if (y < BorderSize || y > (map.GetUpperBound(1)-BorderSize)){  //ensure that borders only placed at correct y coordinates
                    map[x,y] = 0;
                }
            }
        }
        print("Borders Generated");
        return map;
    }

}
