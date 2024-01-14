using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnityMap : MonoBehaviour
{
        public static int[,] GenerateArray(int width, int height, bool empty)
        {
            int[,] map = new int[width, height];
            for (int x = 0; x < map.GetUpperBound(0); x++)
            {
                for (int y = 0; y < map.GetUpperBound(1); y++)
                {
                    if (empty)
                    {
                        map[x, y] = 0;
                    }
                    else
                    {
                        map[x, y] = 1;
                    }
                }
            }
            return map;
        }

        public static void RenderMap(int[,] map, Tilemap tilemap, TileBase tile)
        {
            //Clear the map (ensures we dont overlap)
            tilemap.ClearAllTiles();
            //Loop through the width of the map
            for (int x = 0; x < map.GetUpperBound(0) ; x++)
            {
                //Loop through the height of the map
                for (int y = 0; y < map.GetUpperBound(1); y++)
                {
                    // 1 = tile, 0 = no tile
                    if (map[x, y] == 1)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                    }
                }
            }
        }

         public static void UpdateMap(int[,] map, Tilemap tilemap) //Takes in our map and tilemap, setting null tiles where needed
        {
            for (int x = 0; x < map.GetUpperBound(0); x++)
            {
                for (int y = 0; y < map.GetUpperBound(1); y++)
                {
                    //We are only going to update the map, rather than rendering again
                    //This is because it uses less resources to update tiles to null
                    //As opposed to re-drawing every single tile (and collision data)
                    if (map[x, y] == 0)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), null);
                    }
                }
            }
        }

         public static int[,] PerlinNoise(int[,] map, float seed)
        {
            int newPoint;
            //Used to reduced the position of the Perlin point
            float reduction = 0.5f;
            //Create the Perlin
            for (int x = 0; x < map.GetUpperBound(0); x++)
            {
                newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(x, seed) - reduction) * map.GetUpperBound(1));

                //Make sure the noise starts near the halfway point of the height
                newPoint += (map.GetUpperBound(1) / 2);
                for (int y = newPoint; y >= 0; y--)
                {
                    map[x, y] = 1;
                }
            }
            return map;
        }

        public static int[,] PerlinNoiseSmooth(int[,] map, float seed, int interval)
    {
        //Smooth the noise and store it in the int array
        if (interval > 1)
        {
            int newPoint, points;
            //Used to reduced the position of the Perlin point
            float reduction = 0.5f;

            //Used in the smoothing process
            Vector2Int currentPos, lastPos;
            //The corresponding points of the smoothing. One list for x and one for y
            List<int> noiseX = new List<int>();
            List<int> noiseY = new List<int>();

            //Generate the noise
            for (int x = 0; x < map.GetUpperBound(0); x += interval)
            {
                newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(x, (seed * reduction))) * map.GetUpperBound(1));
                noiseY.Add(newPoint);
                noiseX.Add(x);
            }

            points = noiseY.Count;

            //Start at 1 so we have a previous position already
            for (int i = 1; i < points; i++)
            {
                //Get the current position
                currentPos = new Vector2Int(noiseX[i], noiseY[i]);
                //Also get the last position
                lastPos = new Vector2Int(noiseX[i - 1], noiseY[i - 1]);

                //Find the difference between the two
                Vector2 diff = currentPos - lastPos;

                //Set up what the height change value will be
                float heightChange = diff.y / interval;
                //Determine the current height
                float currHeight = lastPos.y;

                //Work our way through from the last x to the current x
                for (int x = lastPos.x; x < currentPos.x; x++)
                {
                    for (int y = Mathf.FloorToInt(currHeight); y > 0; y--)
                    {
                        map[x, y] = 1;
                    }
                    currHeight += heightChange;
                }

            }
        }
         else
            {
            //Defaults to a normal Perlin gen
            map = PerlinNoise(map, seed);
            }
        return map;
        }

        public static int[,] RandomWalkTop(int[,] map, float seed)
        {
        //Seed our random
        System.Random rand = new System.Random(seed.GetHashCode());

        //Set our starting height
        int lastHeight = Random.Range(0, map.GetUpperBound(1));

        //Cycle through our width
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            //Flip a coin
            int nextMove = rand.Next(2);

            //If heads, and we aren't near the bottom, minus some height
            if (nextMove == 0 && lastHeight > 2)
            {
                lastHeight--;
            }
            //If tails, and we aren't near the top, add some height
            else if (nextMove == 1 && lastHeight < map.GetUpperBound(1) - 2)
            {
                lastHeight++;
            }

            //Circle through from the lastheight to the bottom
            for (int y = lastHeight; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }
        //Return the map
        return map;
        }

        public static int[,] RandomWalkTopSmoothed(int[,] map, float seed, int minSectionWidth)
        {
            //Seed our random
            System.Random rand = new System.Random(seed.GetHashCode());

            //Determine the start position
            int lastHeight = Random.Range(0, map.GetUpperBound(1));

            //Used to determine which direction to go
            int nextMove = 0;
            //Used to keep track of the current sections width
            int sectionWidth = 0;

            //Work through the array width
            for (int x = 0; x <= map.GetUpperBound(0); x++)
            {
                //Determine the next move
                nextMove = rand.Next(2);

                //Only change the height if we have used the current height more than the minimum required section width
                if (nextMove == 0 && lastHeight > 0 && sectionWidth > minSectionWidth)
                {
                    lastHeight--;
                    sectionWidth = 0;
                }
                else if (nextMove == 1 && lastHeight < map.GetUpperBound(1) && sectionWidth > minSectionWidth)
                {
                    lastHeight++;
                    sectionWidth = 0;
                }
                //Increment the section width
                sectionWidth++;

                //Work our way from the height down to 0
                for (int y = lastHeight; y >= 0; y--)
                {
                    map[x, y] = 1;
                }
            }

            //Return the modified map
            return map;
        }

    public int width = 10;
    public int height = 10;
    public Tile TileBase;
    public Tilemap Tilemap;
    public float seed = 10f;
    public int interval = 5;
    public int sectionW = 5;
    private int[,] world;
    public int num = 2;

    void Start () {
        world = GenerateArray(width,height,true);
        
        if (num == 0){
            world = RandomWalkTopSmoothed(world,seed,sectionW);
            }
        else if (num == 1){
            world = PerlinNoiseSmooth(world, seed, interval);
            }
        else if (num == 2){
            world = RandomWalkTop(world,seed);
            }
        else if (num == 3) {
            world = PerlinNoise(world,seed);
            }
            
            RenderMap(world, Tilemap, TileBase);
            UpdateMap(world, Tilemap);
        }
        //world = PerlinNoiseSmooth(world, seed, interval);
        
        

    
    void Update(){
        
    }

}
