using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class HotBarV2 : MonoBehaviour
{
    private Tile[] Tiles;
    private int CurTile;
    public int HotBarLimit;
    public GameObject Items;
    private GameObject curItem;
    private GameObject tileImage;

    public TMP_Text Text;

    // Start is called before the first frame update
    void Start(){
        Tiles = WorldGenerator.WorldTiles;
        FillHotbar();
    }



    // Update is called once per frame
    void Update(){
        CurTile = GameObject.Find("PlayerCharacter").GetComponent<PlayerMining>().block;
        CurTile = Mathf.Clamp(CurTile,0,HotBarLimit);
        print(CurTile);
        Tiles = WorldGenerator.WorldTiles;
        FillHotbar();
        LoadTileName(Tiles[CurTile]);
        HighlightTile(CurTile);
  
    }

    void FillHotbar(){
        for (int i = 1; i <= Items.transform.childCount; i++){
            SetTile(Tiles, i);
        }
    }
    
    void SetTile(Tile[] tiles, int HotbarPosition){
        tileImage = Items.transform.GetChild(HotbarPosition-1).gameObject;
        Sprite tileSprite = (tiles[HotbarPosition].sprite);
        tileImage.GetComponent<Image>().sprite = tileSprite;
        tileImage.GetComponent<Image>().color = new Color32(128,128,128,100);
        tileImage.GetComponent<RectTransform>().sizeDelta = new Vector2(30,30);
        
    }

    void HighlightTile(int HotbarPosition){
        curItem = Items.transform.GetChild(HotbarPosition-1).gameObject;
        curItem.GetComponent<Image>().color = new Color32(255,255,255,255);
        curItem.GetComponent<RectTransform>().sizeDelta = new Vector2(35,35);
    }

    void LoadTileName(Tile tile){
        string tileName = (tile.name);

        if (tileName != null){
            Text.text = (tileName);
        }

        //print(tile);
    }

}
