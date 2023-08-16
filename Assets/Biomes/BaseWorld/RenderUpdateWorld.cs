using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RenderUpdateWorld : MonoBehaviour
{
    public static void RenderMap(int[,] map, Tilemap Tilemap, Tile[] Tiles){
        //Clear the map (ensures we dont overlap)
        Tilemap.ClearAllTiles();
    
        Tile Tile = null;
        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++){
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++){

                if (map[x, y] == -1){

                    Tile = null;
                }
                else{
                    Tile = Tiles[((int) map[x,y])];
                }

                Tilemap.SetTile(new Vector3Int(x,y,0), Tile);
            }
        }

    }

    public static void UpdateMap(int[,] map, Tilemap Tilemap, Tile[] Tiles) //Takes in our map and Tilemap, setting null Tiles where needed
    {
        Tile Tile = null;
   
        for (int x = 0; x < map.GetUpperBound(0)-1; x++){
            for (int y = 0; y < map.GetUpperBound(1)-1; y++){
                
                if (map[x, y] == -1){
                    Tile = null;
                }
                else{
                    Tile = Tiles[((int) map[x,y])]; 
                }

                Tilemap.SetTile(new Vector3Int(x,y,0), Tile);
            }
        }
    }
}
