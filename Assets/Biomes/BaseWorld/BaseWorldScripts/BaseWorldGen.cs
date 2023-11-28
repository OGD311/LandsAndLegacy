using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWorldGen : MonoBehaviour {

    public static int[,] GenerateBasic(int[,] map){
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 0; y < map.GetUpperBound(1); y++){

                if (y < (int)(map.GetUpperBound(1)/3.5)){
                    map[x,y] = 2;
                }

                else if (y < (int)(map.GetUpperBound(1)/2.5)){
                    map[x,y] = 1;
                }

                else{
                    map[x,y] = -1;
                }
            }

        }
        print("Stone and Dirt Placed");
        return map;
    }

    public static int[,] GenerateGrass(int[,] map){
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = map.GetUpperBound(1)/5; y < map.GetUpperBound(1)-1; y++){

                if ((map[x,y-1] != -1) && (map[x,y-1] == 1) && (map[x,y+1] == -1)){
                    map[x,y] = 3;
                }
            }
        }
        print("Grass Placed");
        return map;

    }

    public static int[,] GenerateBorders(int[,] map, int BorderSize){
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 0; y < map.GetUpperBound(1); y++){
                if (x < BorderSize || x > (map.GetUpperBound(0)-BorderSize)){
                    map[x,y] = 0;
                }

                if (y < BorderSize || y > (map.GetUpperBound(1)-BorderSize)){
                    map[x,y] = 0;
                }
            }
        }
        print("Borders Generated");
        return map;
    }

}
