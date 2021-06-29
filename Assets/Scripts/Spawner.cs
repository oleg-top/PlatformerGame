using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float time = 2;
    public float repeatTime = 2;
    public float x = 0;
    public float y = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time >= time)
        {
            var something = Instantiate(prefab);
            something.transform.position = new Vector2(x, y);
            time += repeatTime;
        }
    }
}
