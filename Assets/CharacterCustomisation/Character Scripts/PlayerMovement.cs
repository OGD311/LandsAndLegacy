using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed = 10f;
    public float jumpHeight = 3.0f;
    public float sprintMult = 1.25f;

    // Jumping
    public bool canJump;
    private Rigidbody2D rb2D;

    // Loaded Screen
    private GameObject screen;
    private bool isLoaded = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); // Get Rigidbody
        screen = GameObject.Find("LOADING"); // Find the screen once and store it
    }

    private void Update()
    {
        // Check for jump input
        if (canJump && Input.GetButtonDown("Jump")){ // Use GetButtonDown for better input handling
            rb2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            //canJump = false; // Reset canJump to prevent multi-jumping
        }
    }

    private void FixedUpdate(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float sprintMultiplier = Input.GetButton("Sprint") ? sprintMult : 1.0f;

        Vector2 movement = new Vector2(horizontalInput * moveSpeed * sprintMultiplier, rb2D.velocity.y);
        rb2D.velocity = movement;

        if (horizontalInput < 0){
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput > 0){
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;

        if (isLoaded == false)
        {
            screen.SetActive(false);
            isLoaded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}