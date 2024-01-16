using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour{

    public GameObject PlayerCharacter;
    public GameObject Enemy;
    public float moveSpeed;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start(){
        rb2D = GetComponent<Rigidbody2D>();
        PlayerCharacter = GameObject.Find("PlayerCharacter");
        Enemy = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate(){
        float Px = PlayerCharacter.transform.position.x;
        float Py = PlayerCharacter.transform.position.y;

        float curX = Enemy.transform.position.x;
        float curY = Enemy.transform.position.y;

        float distance = Mathf.Sqrt(Mathf.Pow(Px-curX,2) + Mathf.Pow(Py-curY,2));
        if (distance > 200){
            Destroy(Enemy);
        }
        moveTowards(Px,Py);
        
    }

    void moveTowards(float x, float y){
        Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;  // Calculate the direction to the target (player)  
        rb2D.velocity = direction * moveSpeed;   // Set the velocity of the Rigidbody2D to move towards the target
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject == PlayerCharacter){
            GameObject.Find("Health").GetComponent<PlayerHealth>().Damage(5);
        }
    }

}
