using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius = 0.2f;
    public bool canJunp = true;
    public  float jumpChargeTime;
    public bool candoubleJump = true;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        jump();
        if(isGrounded == false )
        {
            doubleJump();
        }
    }

    private void doubleJump()
    {
        if (Input.GetButtonDown("Jump") && candoubleJump == true){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, (jumpForce / 2) + 1);
            candoubleJump = false;
        }
        if (canJunp == true)
        {
            candoubleJump = true;
        }
    }

    void FixedUpdate()
    {
        // Horizontal Movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
    private void jump()
    {

        // Jumping
        if (Input.GetButton("Jump") && canJunp)  
        {

            jumpChargeTime = jumpChargeTime + Time.deltaTime; // Charge jump force over time
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpChargeTime);


            if (jumpChargeTime >= 6.5f)
            {
                canJunp = false;
            }
        }
        if (isGrounded == true)
        {
            jumpChargeTime = jumpForce;
            canJunp = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            canJunp = false;
        }
    }
}

