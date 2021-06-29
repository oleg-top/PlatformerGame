using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private Image _blackScreen;
    [SerializeField] private GameObject _pauseMenu;
    public void Toggle()
    {
        bool pause = !_blackScreen.enabled;
        _blackScreen.enabled = pause;
        _pauseMenu.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
    }
}
