using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion : MonoBehaviour
{
    public Vector2 MoveVector;
    public float firstChange = 0;
    public float interval = 2;

    private SpriteRenderer sprite;
    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeDirection", firstChange, interval);
        rbody.velocity = MoveVector;
        if (gameObject.tag == "UpperEnemy")
        {
            sprite = GetComponentInChildren<SpriteRenderer>();
        }
    }

    void Update()
    {

    }

    private void ChangeDirection()
    {
        MoveVector = -MoveVector;
        if (gameObject.tag == "UpperEnemy")
        {
            sprite.flipX = !sprite.flipX;
        }
        rbody.velocity = MoveVector;
    }

}
