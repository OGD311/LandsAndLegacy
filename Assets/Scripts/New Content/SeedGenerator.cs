using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    public static int GenerateSeed(string pubseed)
    {
        string seedconv = "";
        int seed;

        if (pubseed.Length != 0)
        {
            // Truncate pubseed to a maximum length of 3
            if (pubseed.Length > 3)
            {
                pubseed = pubseed.Substring(0, 3);
            }

            foreach (char c in pubseed)
            {
                seedconv = seedconv + (System.Convert.ToInt32(c));
            }
        }
        else
        {
            for (int i = 0; i <= 2; i++)
            {
                seedconv = seedconv + (int)(Random.value * 1000);
            }
        }

        seed = int.Parse(seedconv);
        return seed;
    }
}
