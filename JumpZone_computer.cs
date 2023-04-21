using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone_computer : MonoBehaviour
{
    [SerializeField] float jumpForce = 400f, speed = 5f, jumpZoneForce = 2f;
    int jumpCount = 1;
    float moveX;

    bool isGround = false;
    bool isJumpZone = false;
    Rigidbody2D rb;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
            jumpCount = 1;
        }
        if (col.gameObject.tag == "JumpZone")
        {
            isJumpZone = true;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (isGround)
        {
            if (jumpCount > 0)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector2.up * jumpForce);
                    jumpCount--;
                }
            }
            if (isJumpZone)
            {
                rb.AddForce(new Vector2(0, jumpZoneForce) * jumpForce);
                isJumpZone = false;
            }
        }
        
    }
   
}
