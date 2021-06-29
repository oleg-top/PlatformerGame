using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerTrigger : MonoBehaviour
{
    public UnityEvent OnPlayerEnter, OnPlayerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
        {
            OnPlayerEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var _))
        {
            OnPlayerExit.Invoke();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
