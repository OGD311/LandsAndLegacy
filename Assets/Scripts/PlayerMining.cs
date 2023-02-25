using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMining : MonoBehaviour
{
    public Tile[] placeTiles;
    public Tilemap tileMap;

    void Start(){
        //tileMap = GetComponent<Tilemap>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            breakBlock();
        }
        else if (Input.GetMouseButtonDown(1)){
            placeBlock();
        }
    }

    void breakBlock() {
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var worldPoint = new Vector2Int((int)(mousePoint.x), (int)(mousePoint.y));
        tileMap.SetTile(new Vector3Int(worldPoint.x,worldPoint.y, 0), null);
        
    }

    void placeBlock(){
        Tile tile = null;
        tile = placeTiles[0];
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var worldPoint = new Vector2Int((int)(mousePoint.x), (int)(mousePoint.y));
        tileMap.SetTile(new Vector3Int(worldPoint.x,worldPoint.y, 0), tile);
        
    }
}