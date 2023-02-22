using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    //Variables
    public float moveSpeed = 1.5f;
    public float jumpHeight = 3.0f;
    public Rigidbody2D RigidBody;
    public Vector2 direction;
    public float ColliderHeight = 2.0f;

    //Vector that stores movement direction
    Vector2 movement;

    void Start (){
        Ray2D ray = new Ray2D(transform.position, direction);
    }


    //Update called once per frame
    void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        movement.x = Input.GetAxisRaw("Horizontal");
        if (hit.distance <= (ColliderHeight/2))
            {
                movement.y = Input.GetAxisRaw("Jump");
            }
        else {
            movement.y = 0.0f;
        }

    }

    void FixedUpdate()
    {
       /* if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpHeight,ForceMode2D.Impulse);
        }*/
        movement = new Vector2(movement.x*moveSpeed,movement.y*jumpHeight);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

}
