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
        float Px = PlayerCharacter.transform.position.x;
        float Py = PlayerCharacter.transform.position.y;

        float curX = Enemy.transform.position.x;
        float curY = Enemy.transform.position.y;

        float distance = Mathf.Sqrt(Mathf.Pow(Px-curX,2) + Mathf.Pow(Py-curY,2));
        if (distance > 100){
            Destroy(Enemy);
        }
        moveTowards(Px,Py);
        
    }

    void moveTowards(float x, float y){
        Vector2 direction = new Vector2(x - transform.position.x, 0).normalized;  // Only change in the X direction
        rb2D.velocity = new Vector2(direction.x * moveSpeed, rb2D.velocity.y);   // Preserve the current Y-axis velocity (gravity)
        if (direction.x < 0){
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x > 0){
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == PlayerCharacter){
            GameObject.Find("Health").GetComponent<PlayerHealth>().Damage(5);
        }
    }

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject == GameObject.Find("World") && Random.Range(1,10) == 1){
            rb2D.velocity = new Vector2(rb2D.velocity.x, 5f);
        }
    }


}
