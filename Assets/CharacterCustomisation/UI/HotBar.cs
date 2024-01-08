using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HotBar : MonoBehaviour
{
    private Tile[] Tiles;
    private int CurTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tiles = WorldGenerator.WorldTiles;
        CurTile = 1;
        LoadTileImage(Tiles[CurTile]);
    }

    void LoadTileImage(Tile tile)
    {
        // Assuming tile.Name corresponds to the image file name in the Resources folder
        Sprite tileSprite = (tile.sprite);

        if (tileSprite != null)
        {
            print("Tile Found");
            // Apply this sprite to a GameObject, e.g., a UI Image or a SpriteRenderer
            // Example for a SpriteRenderer:
            GetComponent<SpriteRenderer>().sprite = tileSprite;
        }

        print(tile);

    }
}


// ("Assets/Biomes/TileImages/" + tile.sprite + ".png");