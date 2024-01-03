using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMining : MonoBehaviour
{   
    public static void breakBlock(int[,] map, Tilemap Tilemap, Tile[] tiles) {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var worldPoint = new Vector2Int((int)(mousePoint.x), (int)(mousePoint.y));
        print(Input.mousePosition.x);
        print(worldPoint.x+" "+worldPoint.y);
        map[worldPoint.x,worldPoint.y] = -1;

        RenderUpdateWorld.UpdateMap(map,Tilemap,tiles);
    }

    public static void placeBlock(int[,] map, int block, Tilemap Tilemap, Tile[] tiles){
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var worldPoint = new Vector2Int((int)(mousePoint.x), (int)(mousePoint.y));
        map[worldPoint.x,worldPoint.y] = block;
        print(worldPoint.x+" "+worldPoint.y);
        RenderUpdateWorld.UpdateMap(map,Tilemap,tiles);
    }

    public int[,] map;
    public Tilemap WorldTilemap;
    private Tile[] WorldTiles;

    public GameObject World;

    public int block = 0;

    //public GameObject PlayerCharacter; 

    void start(){
    }

    // Update is called once per frame
    void Update()
    {
        map = WorldGenerator.map;
        WorldTilemap = WorldGenerator.Tilemap;
        WorldTiles = WorldGenerator.Tile;

        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0){
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && block <= WorldTiles.Length){
                block ++;
                print(block);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && block > 0){
                block --;
                print(block);
                
            }
        }
        else if (Input.GetMouseButtonDown(0)){
            breakBlock(map,WorldTilemap,WorldTiles);
            
        }
        else if (Input.GetMouseButtonDown(1)){
            placeBlock(map, block, WorldTilemap, WorldTiles);
            
        }
    }
}