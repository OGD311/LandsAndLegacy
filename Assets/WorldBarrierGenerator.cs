using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBarrierGenerator : MonoBehaviour
{
    public GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        int[,] world = GameObject.Find("Landscape (1)").GetComponent<NewWorldGen>().world;


        Instantiate(prefab, new Vector3(-50,0,0), Quaternion.identity);
        Instantiate(prefab, new Vector3(world.GetUpperBound(0),0,0), Quaternion.identity);
        Instantiate(prefab, new Vector3(world.GetUpperBound(1)+50,0,0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
