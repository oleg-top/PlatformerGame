using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4;
    public float jumpForce = 5;
    public int maxJumps = 2;
    public enum ControlType { PC, Mobile }

    public ControlType _control = ControlType.PC;

    private bool jumpOrder;
    private Rigidbody2D rbody;
    private Animator myAnimator;
    private SpriteRenderer sprite;
    private int jumps = 0;
    private VariableJoystick _joystick;
    
    void Start()
    {
        if (ControlCheck.PcControl)
        {
            _control = ControlType.PC;
        }
        else
        {
            _control = ControlType.Mobile;
        }
        rbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        _joystick = GetComponentInChildren<VariableJoystick>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = maxJumps;
        }
    }

    public void SetJumpOrder()
    {
        jumpOrder = true;
    }

    void Update()
    {
        jumpOrder |= Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        var horizontal = ControlType.PC == _control ? Input.GetAxis("Horizontal") : _joystick.Horizontal;
        var axisActive = ControlType.PC == _control ? Input.GetButton("Horizontal") : Mathf.Abs(_joystick.Horizontal) > 0.1f;
        var velocity = rbody.velocity;
        velocity.x =  horizontal * moveSpeed;
        myAnimator.SetBool("walk", axisActive);
        if (axisActive)
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
