using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class WorldGenerator : MonoBehaviour{

    public static int[,] GenerateArray(int mapSizeX, int mapSizeY, bool empty, int WalkMin)
    {
        int NotOnlyStone = 0;
        int[,] map = new int[mapSizeX, (int)mapSizeY*3];

        for (int x = 0; x < mapSizeX; x++){
            for (int y = 0; y < mapSizeY*3; y++){
                map[x,y] = -1;

            }
        }

        while (NotOnlyStone == 0){
            
            
            int WalkNo = 0;
            int stoneDepth = Random.Range((mapSizeY/3), (mapSizeY/2)-10);
            int prevGrassLevel = 0;
            int grassLevel = (int)((mapSizeY-(mapSizeY/7)));

            for (int x = 0; x < mapSizeX; x++) 
            {
                
                int prevStoneDepth = stoneDepth + Random.Range(-4,4);
                
                int mudDepth = grassLevel - prevStoneDepth;
                if (mudDepth > (mapSizeY/3)){
                    mudDepth = (mapSizeY/3);
                }

                if (prevStoneDepth > (mapSizeY/2)){
                    prevStoneDepth = (mapSizeY/2)-10;
                }
                if ((WalkNo % WalkMin) == 0){
                    int nextmove = Random.Range(0,100);
                    if (nextmove < 33){
                        grassLevel -- ;
                    }
                    else if (nextmove > 33 && nextmove < 66){
                        grassLevel ++;
                    }
                    else{
                        grassLevel = prevGrassLevel;
                    }

                    if (grassLevel > mapSizeY){
                        mapSizeY = (mapSizeY+grassLevel);
                    }
                }
                    WalkNo ++;
                for (int y = 0; y < mapSizeY; y++)
                {
                    if (y < prevStoneDepth)
                    {   
                        map[x,y] = 0;
                    }
                    else if (y < grassLevel && y >= prevStoneDepth)
                    {   
                        map[x,y] = 1;
                        NotOnlyStone ++;
                    }
                    else if (y == grassLevel)
                    {   
                        map[x,y] = 2 ;
                        NotOnlyStone ++;         
                    }
                    else{
                        map[x,y] = -1;
                    }
                
                }

                prevGrassLevel = grassLevel;
            }


        }
        return map;
    
        
    }


    public static void RenderMap(int[,] map, Tilemap tilemap, Tile[] tiles)
    {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();
    
        Tile tile = null;
        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0) ; x++)
        {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {

                if (map[x, y] == -1)
                {
                    tile = null;
                }
                else{
                    tile = tiles[((int) map[x,y])];

                    
                }
                tilemap.SetTile(new Vector3Int(x,y,0), tile);
            }
        }

    }

    public static void UpdateMap(int[,] map, Tilemap tilemap, Tile[] tiles) //Takes in our map and tilemap, setting null tiles where needed
    {
        Tile tile = null;
        for (int x = 0; x < map.GetUpperBound(0)+1; x++)
        {
            for (int y = 0; y < map.GetUpperBound(1)+1; y++)
            {
                if (map[x, y] == -1)
                {
                    tile = null;
                }
                else{
                    tile = tiles[((int) map[x,y])];
                    
                }
                tilemap.SetTile(new Vector3Int(x,y,0), tile);
            }
        }
    }


    public static void MapVariety(int[,] map, int mapSizeX, int mapSizeY, Tilemap tilemap){
        for (int i = 0; i < (int)mapSizeX/10; i++){
                int x = Random.Range(0,mapSizeX);
                int y = Random.Range(0,mapSizeY/3);
                int OreSize = Random.Range(3,4);
                int Ore = Random.Range(3,7);

                try{
                    map[x,y] = Ore;
                    map[x+1,y] = Ore;
                    map[x-1,y] = Ore;
                    map[x,y+1] = Ore;
                    map[x,y-1] = Ore;
                /*    map[x+1,y+1] = Ore;
                    map[x+1,y-1] = Ore;
                    map[x-1,y+1] = Ore;
                    map[x-1,y-1] = Ore;
                */}
                catch{
                    print("Awww");
                }
               
            

       /* for (int i = 0; i < Random.Range(1,6); i++){
            map[x,y] == Random.Range(3,8);
        }*/
        }
    }

    public int width = 10;
    public int height = 10;
    public Tile[] WorldTiles;
    public Tilemap Tilemap;
    public int[,] world;
    public int WalkMin = 3;

    void Start(){
        while (true == true){
        try{
        world = GenerateArray(width, height, false, WalkMin);
            try{
                MapVariety(world, width, height, Tilemap);

            }
            catch{
                MapVariety(world,width, height, Tilemap);
            }
            break;
        }

        catch{
        world = GenerateArray(width, height, false, WalkMin);
            try{
                MapVariety(world, width, height, Tilemap);
                break;
            }
            catch{
                MapVariety(world,width, height, Tilemap);
            }
            break;
        }
        }
        
        
        //MapVariety(world,width, height, Tilemap);
        RenderMap(world, Tilemap, WorldTiles);
       // UpdateMap(world, Tilemap);
    }


    //Player mining
    public static void breakBlock(int[,] map, Tilemap Tilemap, Tile[] tiles) {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var worldPoint = new Vector3Int((int)(mousePoint.x), (int)(mousePoint.y),0);
        Vector3Int cellposition = Tilemap.WorldToCell(worldPoint);
        map[cellposition.x,cellposition.y] = -1;
        print(worldPoint.x+" "+worldPoint.y);
        UpdateMap(map,Tilemap,tiles);
    }

    public static void placeBlock(int[,] map, int block, Tilemap Tilemap, Tile[] tiles){
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var worldPoint = new Vector3Int((int)(mousePoint.x), (int)(mousePoint.y),0);
        Vector3Int cellposition = Tilemap.WorldToCell(worldPoint);
        if (map[cellposition.x,cellposition.y] == -1){
            map[cellposition.x,cellposition.y] = block;
        }
        else{
            print("Cannot place - block already there");
        }
        
        print(worldPoint.x+" "+worldPoint.y);
        print(cellposition.x+" "+cellposition.y);
        UpdateMap(map,Tilemap,tiles);
    }

    public int block = 0;
    public GameObject PlayerCharacter; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0){
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && block <= WorldTiles.GetUpperBound(0)){
                if (block == WorldTiles.GetUpperBound(0)){
                    block = 0;
                }
                else{
                    block ++;
                }
                
                print(WorldTiles[block]+" "+block);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && block > 0){
               /* if (block < 0){
                    block = (WorldTiles.GetUpperBound(0)-1);
                }
                else{*/
                    block --;  
               // }

                print(WorldTiles[block]+" "+block);
                
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