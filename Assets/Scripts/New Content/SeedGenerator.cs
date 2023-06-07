using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SeedGenerator : MonoBehaviour
{
    public string pubseed;
    private string seedconv = "";
    public ulong seed;
    public bool regen = true;


    // Update is called once per frame
    void Update()
    {
        if (regen == true){
            regen = false;
            seed = 0;
            seedconv = "";
            genseed();
            
            
        }

    }

    void genseed()
    {
        //Player chosen seed -> limited to 15 ints long
        if (pubseed.Length != 0){
            
            if (pubseed.Length > 6){
                for (int i = 0; i <= 6; i++){
                    pubseed = pubseed.Substring(0,6);
                }
            }

                foreach(char c in pubseed){
                    seedconv = seedconv + (System.Convert.ToInt32(c));
                }
                if (seedconv.Length < 15){
                    Random.InitState((int)Time.time + Time.frameCount);
                    while (seedconv.Length < 15){
                        seedconv = seedconv + (int)(Random.value*1000);
                    }
                }



            seed = ulong.Parse(seedconv);

            print(seed);
        }

        // comp generated seed approx ~ 15 ints
        else{
            Random.InitState((int)Time.time + Time.frameCount);
            for (int i = 0; i <= 5; i++){
                seedconv = seedconv + (int)(Random.value*1000);
            }

            if (seedconv.Length < 15){
                    while (seedconv.Length < 15){
                        seedconv = seedconv + (int)(Random.value*1000);
                    }
                }

            seed = ulong.Parse(seedconv);

            print(seed);
        }

        
    }
}
