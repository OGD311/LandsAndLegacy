using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DesertGeneration : MonoBehaviour
{   

    
    // Start is called before the first frame update
    void Start(){
        ulong Worldseed = WorldManager.GetComponent<SeedGenerator>().seed;
        Random.InitState((int)(Worldseed));
    }

    public static int[,] GenerateDesert(int startHeight, int worldLength, int[,] map){
        int DesertLength = Random.Range(25,45);
        for (int x = 7; x < (DesertLength); x++){
            for (int y = startHeight-Random.Range(10,13); y <= startHeight+Random.Range(-1,2); y++){
                map[x,y] = 4;
            }
        }
        return map;
    }

    public static int[,] GenerateCacti(int[,] map){
        int NumCacti = Random.Range(2,6);

        return map;
    }

    //Seed
    public GameObject WorldManager;
    private ulong Worldseed;
    

    
}
