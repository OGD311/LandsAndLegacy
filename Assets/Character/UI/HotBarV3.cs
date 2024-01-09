using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class HotBarV3 : MonoBehaviour
{
    private Tile[] Tiles;
    private int CurTile;
    public GameObject Items;
    private GameObject curItem;
    private GameObject tileImage;

    public TMP_Text Text;

    private int currentLayer = 0;
    private const int HotbarSize = 9;

    // Start is called before the first frame update
    void Start(){
        Tiles = WorldGenerator.WorldTiles;
        FillHotbar();
    }

    // Update is called once per frame
    void Update(){
        CurTile = GameObject.Find("PlayerCharacter").GetComponent<PlayerMining>().block;
        Tiles = WorldGenerator.WorldTiles;
        FillHotbar();
        LoadTileName(Tiles[CurTile]);
        HighlightTile((CurTile % HotbarSize)-1);

        print(CurTile % HotbarSize);

        // Handle layer changing
        if(CurTile % HotbarSize > 1){ 
            ClearHotbar();
            while (CurTile % HotbarSize > 1){}
            ChangeLayer(1); 
        }
        if(CurTile % HotbarSize < 1) {
            ClearHotbar();
            ChangeLayer(-1); 
        }
    }

    void FillHotbar(){
        int startTileIndex = currentLayer * HotbarSize;
        for (int i = 0; i < Items.transform.childCount; i++)
        {
            if (startTileIndex + i < Tiles.Length)
            {
                SetTile(Tiles, startTileIndex + i, i);
            }
        }
    }

    void ClearHotbar(){
        int startTileIndex = currentLayer * HotbarSize;
        for (int i = 0; i < HotbarSize; i++){
            if (startTileIndex + i < Tiles.Length)
            {
                DeleteTile(Tiles, startTileIndex + i, i);
            }
        }
    }

    void SetTile(Tile[] tiles, int TileIndex, int HotbarPosition){
        tileImage = Items.transform.GetChild(HotbarPosition).gameObject;
        Sprite tileSprite = (tiles[TileIndex+1].sprite);
        tileImage.GetComponent<Image>().sprite = tileSprite;
        tileImage.GetComponent<Image>().color = new Color32(128, 128, 128, 100);
    }

    void DeleteTile(Tile[] tiles, int TileIndex, int HotbarPosition){
        tileImage = Items.transform.GetChild(HotbarPosition-1).gameObject;
        tileImage.GetComponent<Image>().sprite = null;
        tileImage.GetComponent<Image>().color = new Color32(128, 128, 128, 100);
    }


    void HighlightTile(int HotbarPosition)
    {
        curItem = Items.transform.GetChild(HotbarPosition).gameObject;
        curItem.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    void LoadTileName(Tile tile)
    {
        string tileName = (tile.name);
        if (tileName != null)
        {
            Text.text = tileName;
        }
    }

    void ChangeLayer(int direction)
    {
        currentLayer += direction;
        // Make sure the layer number stays within bounds
        currentLayer = Mathf.Clamp(currentLayer, 0, (Tiles.Length / HotbarSize));
        FillHotbar();
    }
}
