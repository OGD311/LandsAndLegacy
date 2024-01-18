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
        float Px = PlayerCharacter.transform.position.x; // Current Player X
        float Py = PlayerCharacter.transform.position.y; // Current Player Y

        float curX = Enemy.transform.position.x; // Current Enemy X
        float curY = Enemy.transform.position.y; // Current Enemy Y

        float distance = Mathf.Sqrt(Mathf.Pow(Px-curX,2) + Mathf.Pow(Py-curY,2));
        if (distance > 200){ // Despawn enemy if far enough away
            Destroy(Enemy);
        }
        moveTowards(Px,Py); // Move towards player
        
    }

    void moveTowards(float x, float y){
        Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;  // Calculate the direction to the target (player)  
        rb2D.velocity = direction * moveSpeed;   // Set the velocity of the Rigidbody2D to move towards the target
    }


    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject == PlayerCharacter){
            GameObject.Find("Health").GetComponent<PlayerHealth>().UpdateHealth(-0.1f); // Deal damage to the player 
        }
    }

}
