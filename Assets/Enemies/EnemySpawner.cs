using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject FlyingEnemy;
    public GameObject WalkingEnemy;
    public GameObject PlayerCharacter;

    // Start is called before the first frame update
    void Start(){   
        PlayerCharacter = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (this.transform.childCount <= 10){
            if (Time.time % 4 == 0 && Random.Range(0,20) == 1){
                float direction = PlayerCharacter.transform.localScale.x;
                float Px = PlayerCharacter.transform.position.x;
                float Py = PlayerCharacter.transform.position.y;
                Vector3 SpawnPos = new Vector3(Px + Random.Range(20,50) * direction, Py + Random.Range(0,20), 0);


            
                GameObject newEnemy = Instantiate(FlyingEnemy, SpawnPos, Quaternion.Euler(0, 0, 0));
                newEnemy.transform.SetParent(this.transform, worldPositionStays: true);
            }



            if (Time.time % 3 == 0 && Random.Range(0,20) == 8){
                float direction = PlayerCharacter.transform.localScale.x;
                float Px = PlayerCharacter.transform.position.x;
                float Py = PlayerCharacter.transform.position.y;
                Vector3 SpawnPos = new Vector3(Px + Random.Range(15,30) * direction, Py + Random.Range(20,40), 0);


            
                GameObject newEnemy = Instantiate(WalkingEnemy, SpawnPos, Quaternion.Euler(0, 0, 0));
                newEnemy.transform.SetParent(this.transform, worldPositionStays: true);
            }
        }
    }
}
