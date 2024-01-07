using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RenderUpdateWorld : MonoBehaviour
{
    public static void RenderUpdateMap(int[,] map, Tilemap Tilemap, Tile[] Tiles, bool wipeAll = false){
        
        if (wipeAll == true){ // Ensure that map only cleared if necessary
            Tilemap.ClearAllTiles();  //Clear the map (ensures we dont overlap)
        }

        Tile Tile = null;  // Initialise Tile with Null value

        
        for (int x = 0; x < map.GetUpperBound(0); x++){ // Loop through the width of the map
            
            for (int y = 0; y < map.GetUpperBound(1); y++){ // Loop through the height of the map

                if (map[x, y] == -1){
                    Tile = null; // Set empty array value to Null tile
                }
                else{
                    Tile = Tiles[((int) map[x,y])]; //Set array values to relevant tile
                }

                Tilemap.SetTile(new Vector3Int(x,y,0), Tile); // Redraw tile
            }
        }

    }

}
