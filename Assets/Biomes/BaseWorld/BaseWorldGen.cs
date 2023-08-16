using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseWorldGen : MonoBehaviour {

    public Tilemap Tilemap;
    public Tile[] Tiles;
    public static int[,] GenerateBasic(int[,] map, Tilemap Tilemap, Tile[] Tiles){
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 0; y < map.GetUpperBound(1); y++){
                if (y < (int)(map.GetUpperBound(1)/3)){
                    map[x,y] = 2;
                }

                else if (y < (int)(map.GetUpperBound(1)/2)){
                    map[x,y] = 1;
                }

                else{
                    map[x,y] = -1;
                }
            }

        }

        return map;
    }

    public static int[,] GenerateGrass(int[,] map, Tilemap Tilemap, Tile[] Tiles){
        bool Placed = false;
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 1; y < map.GetUpperBound(1)-1; y++){

                if ((map[x,y-1] != -1) && (map[x,y-1] == 1) && (map[x,y+1] == -1) && (Placed == false)){
                    map[x,y] = 3;
                    Placed = true;
                }


            }
            Placed = false;
        }
        return map;

    }

    public static int[,] GenerateBorders(int[,] map, Tilemap Tilemap, Tile[] Tiles){
        for (int x = 0; x < map.GetUpperBound(0); x++){
            for (int y = 0; y < map.GetUpperBound(1); y++){
                if (x < 7 || x > (map.GetUpperBound(0)-7)){
                    map[x,y] = 0;
                }

                if (y < 7 || y > (map.GetUpperBound(1)-7)){
                    map[x,y] = 0;
                }
            }
        }
        return map;
    }

}
