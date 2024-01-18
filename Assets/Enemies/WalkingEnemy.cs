using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour{

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
        if (distance > 100){ // Despawn enemy if far enough away
            Destroy(Enemy);
        }
        moveTowards(Px,Py); // Move towards player
        
    }

    void moveTowards(float x, float y){
        Vector2 direction = new Vector2(x - transform.position.x, 0).normalized;  // Only change in the X direction
        rb2D.velocity = new Vector2(direction.x * moveSpeed, rb2D.velocity.y);   // Preserve the current Y-axis velocity (gravity)
        if (direction.x < 0){
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Flip character based on player direction
        }
        else if (direction.x > 0){
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject == PlayerCharacter){
            GameObject.Find("Health").GetComponent<PlayerHealth>().UpdateHealth(-0.5f); // Deal Damage to the player
        }

        if (collision.gameObject == GameObject.Find("World") && Random.Range(1,10) == 1){ // Jump at random occasions
            rb2D.velocity = new Vector2(rb2D.velocity.x, 5f);
        }
    }


}
