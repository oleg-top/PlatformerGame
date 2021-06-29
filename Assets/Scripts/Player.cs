using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4;
    public float jumpForce = 5;
    public int maxJumps = 2;

    private bool jumpOrder;
    private Rigidbody2D rbody;
    private Animator myAnimator;
    private SpriteRenderer sprite;
    private int jumps = 0;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = maxJumps;
        }
    }

    void Update()
    {
        jumpOrder |= Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        var velocity = rbody.velocity;
        velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        myAnimator.SetBool("walk", Input.GetButton("Horizontal"));
        if (Input.GetButton("Horizontal"))
        {
            sprite.flipX = velocity.x < 0;
        }
        if (jumpOrder)
        {
            if (jumps > 0)
            {
                jumps--;
                velocity.y = jumpForce;
            }
            jumpOrder = false;
        }

        rbody.velocity = velocity;
    }
}
