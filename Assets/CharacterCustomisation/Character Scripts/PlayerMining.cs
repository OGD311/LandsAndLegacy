using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMining : MonoBehaviour
{   
    public static void setBlock(int[,] map, int block, Tilemap Tilemap, Tile[] Tiles){
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get mouse coordinates in the world
        var worldPoint = new Vector2Int((int)(mousePoint.x), (int)(mousePoint.y)); // Get coordinates on a 2d scale
        if (block != -1 && map[worldPoint.x,worldPoint.y] == -1){
            map[worldPoint.x,worldPoint.y] = block; //set coordinate to block
        }
        else if (block == -1){
            map[worldPoint.x,worldPoint.y] = -1;
        }
        
        print(worldPoint.x+" "+worldPoint.y);
        RenderUpdateWorld.UpdateMap(map, Tilemap, Tiles, worldPoint.x, worldPoint.y); //Update the worldmap
    }

    public int[,] map;
    public Tilemap WorldTilemap;
    public Tile[] WorldTiles;
    public GameObject World;

    public int block = 1;


    // Update is called once per frame
    void Update()
    {
        map = WorldGenerator.map;


        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0){
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && block <= WorldTiles.Length-1){ // Increase the current block on scroll up
                block ++;
                print(WorldTiles[block]);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && block > 1){ // Decrease the current block on scroll down (lower end limit is 1 as 0 is worldborder)
                block --;
                print(WorldTiles[block]);
                
            }
        }
        else if (Input.GetMouseButtonDown(0)){ // Right click
            setBlock(map, -1, WorldTilemap, WorldTiles); // Place null block (air)
            
        }
        else if (Input.GetMouseButtonDown(1)){ // Left click
            setBlock(map, block, WorldTilemap, WorldTiles); // Place current selected block
            
        }
    }
}