using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    public float endTime = 2;

    void Start()
    {
        endTime = Time.time + endTime;
    }

    void Update()
    {
        if (Time.time >= endTime)
        {
            Destroy(gameObject);
        }
    }
}
