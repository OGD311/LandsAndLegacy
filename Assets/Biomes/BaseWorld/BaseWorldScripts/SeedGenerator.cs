using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    public static void GenerateSeed(string publicSeed) //static void as nothing will be returned (it is a procedure rather than a function)
    {
        string seedConversion = ""; //holds the current seed as a string before its conversion to an integer
        int seed; //holds the outputted seed
        Random.InitState((int)(Time.fixedTime + Time.time)); //Initialises random based on current game time (Time.fixedTime) and current real world time (Time.time)

        if (publicSeed.Length != 0) //Checks the length of the public seed to decide if a computer generated one is needed
        {
           
            if (publicSeed.Length > 3)
            {
                publicSeed = publicSeed.Substring(0, 3); //Truncate publicSeed to a maximum length of 3
            }

            foreach (char C in publicSeed){
                seedConversion = seedConversion + (System.Convert.ToInt32(C)); //Convert each character from a 'char' to a 32bit integer
            }

        }

        else{

            for (int i = 0; i <= 2; i++){
                seedConversion = seedConversion + (int)(Random.value * 1000); //Generate a random seed if none is supplied
            }
           
        }

        seed = int.Parse(seedConversion); //Convert the seed to an integer
        Random.InitState(seed); //Initialise random with the seed
    }
}