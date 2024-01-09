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
    private Tile[] Tiles;
    public GameObject World;

    public int block = 1;

    void Start(){
    }


    // Update is called once per frame
    void Update()
    {
        map = WorldGenerator.map;
        Tiles = WorldGenerator.WorldTiles;


        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0){
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && block <= (Tiles.Length-2)){ // Increase the current block on scroll up
                block ++;
                print(Tiles[block]);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && block > 1){ // Decrease the current block on scroll down (lower end limit is 1 as 0 is worldborder)
                block --;
                print(Tiles[block]);
                
            }
        }
        else if (Input.GetMouseButtonDown(0)){ // Right click
            setBlock(map, -1, WorldTilemap, Tiles); // Place null block (air)
            
        }
        else if (Input.GetMouseButtonDown(1)){ // Left click
            setBlock(map, block, WorldTilemap, Tiles); // Place current selected block
            
        }
    }
}