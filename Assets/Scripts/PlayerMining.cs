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
        WorldGenerator.UpdateMap(map,Tilemap,tiles);
    }

    public static void placeBlock(int[,] map, int block, Tilemap Tilemap, Tile[] tiles){
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var worldPoint = new Vector2Int((int)(mousePoint.x), (int)(mousePoint.y));
        map[worldPoint.x,worldPoint.y] = block;
        print(worldPoint.x+" "+worldPoint.y);
        WorldGenerator.UpdateMap(map,Tilemap,tiles);
    }

    private int[,] world;
    private Tilemap Tilemap;
    public Tile[] WorldTiles;

    [SerializeField]
   // public int[,] world;

    public int block = 0;
    //public GameObject PlayerCharacter; 

    void start(){
        int[,] world = GameObject.Find("Landscape").GetComponent<WorldGenerator>().world;
        Tilemap Tilemap = GameObject.Find("Landscape").GetComponent<WorldGenerator>().Tilemap;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0){
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && block <= 6){
                block ++;
                print(block);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && block > 0){
                block --;
                print(block);
                
            }
        }
        else if (Input.GetMouseButtonDown(0)){
            breakBlock(world,Tilemap,WorldTiles);
            
        }
        else if (Input.GetMouseButtonDown(1)){
            placeBlock(world, block, Tilemap, WorldTiles);
            
        }
    }
}