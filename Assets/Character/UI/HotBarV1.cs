using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class HotBarV1 : MonoBehaviour
{
    private Tile[] Tiles;
    private int CurTile;
    private GameObject tileImage;
    public TMP_Text Text;

    // Start is called before the first frame update
    void Start(){
        Tiles = WorldGenerator.WorldTiles;
    }

    // Update is called once per frame
    void Update(){
        CurTile = GameObject.Find("PlayerCharacter").GetComponent<PlayerMining>().block;
        Tiles = WorldGenerator.WorldTiles;
        print(Tiles[CurTile]);
        SetTile(Tiles[CurTile]);
        TileName(Tiles[CurTile]);
    }
    
    void SetTile(Tile tile){
        Sprite tileSprite = (tile.sprite);
        tileImage.GetComponent<Image>().sprite = tileSprite;
        
    }

    void TileName(Tile tile){
        string tileName = (tile.name);

        if (tileName != null){
            Text.text = (tileName);
        }

    }

}
