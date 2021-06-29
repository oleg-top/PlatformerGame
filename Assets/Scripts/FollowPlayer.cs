using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 3;
    public float dontTouch = 2;
    
    private Transform player;
    private SpriteRenderer sprite;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        transform.right = player.transform.position - transform.position;
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        sprite.flipY = player.transform.position.x < transform.position.x;
    }
}
