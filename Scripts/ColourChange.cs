using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public float red = 0;
    public float green = 0;
    public float blue = 0;
    

    void Start () {
 
     // pick a random color
     Color newColor = new Color(red,green,blue, 1.0f );
 
     // apply it on current object's material
     GetComponent<Renderer>().material.color = newColor;   
 
 }
}
