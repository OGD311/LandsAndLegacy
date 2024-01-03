using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    //MovementVariables
    public float moveSpeed = 10f;
    public float jumpHeight = 3.0f;
    public float sprintMult = 1.25f;
    public float dashSpeed = 5.5f;


    //Jumping
    public bool canJump;
    private Rigidbody2D rb2D;

    //Vector that stores movement direction
    Vector2 movement;
    public Vector2 direction = new Vector2(0, -0.5f);
    

    void Start (){
        Ray2D ray = new Ray2D(transform.position, direction);
        rb2D = GetComponent<Rigidbody2D>();
    }


    //Update called once per frame
    void Update () {   
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        movement.x = Input.GetAxisRaw("Horizontal");

        //Allow Jumping if grounded
        if (canJump == true && Input.GetAxisRaw("Vertical") > 0){
            movement.y = 1;
        }

    }

    //Can jump if touching ground or other object
    void OnCollisionEnter2D(){
        canJump = true;
    }

    void OnCollisionExit2D(){
        canJump = false;
    }

    void FixedUpdate()
    {
        float sprintMultiplier = 1.0f;
        
        if (Input.GetButton("Sprint") == true){
            sprintMultiplier = sprintMult;
        }

        movement = new Vector2(movement.x*moveSpeed*sprintMultiplier, movement.y*jumpHeight);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (movement.x < 0) {
            GetComponent<SpriteRenderer>().flipX = true; 
        }
        if (movement.x > 0) {
            GetComponent<SpriteRenderer>().flipX = false; 
        }

    }





}