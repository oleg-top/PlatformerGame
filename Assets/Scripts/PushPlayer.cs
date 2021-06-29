using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;
    public Vector2 pushDirection = Vector2.up;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
        {
            playerRigidbody2D = collision.GetComponent<Rigidbody2D>();
            enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
        {
            if (playerRigidbody2D && collision.gameObject == playerRigidbody2D.gameObject)
            {
                enabled = false;
            }
        }
    }
    void Start()
    {
        enabled = false;
    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity += pushDirection;
    }
}
