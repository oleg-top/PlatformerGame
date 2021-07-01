using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinToMenu : MonoBehaviour
{
    public UnityEvent OnButtonPressed;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnButtonPressed.Invoke();
        }
    }
}
