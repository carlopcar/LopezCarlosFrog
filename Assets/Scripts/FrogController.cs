using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float runSpeed = 1.5f;
    public float jumpSpeed = 3f;

    Rigidbody2D rb;


    public bool betterJump = false;
    public float normalJump = 0.5f;
    public float lowJump = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        }
        else if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x , jumpSpeed);
        }

        if (betterJump)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (normalJump) * Time.deltaTime;
            }
            if (rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJump) * Time.deltaTime;
            }
        }
    }
}
