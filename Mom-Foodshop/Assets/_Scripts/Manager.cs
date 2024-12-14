using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Button _btnQuit;

    private void Awake()
    {
        _btnQuit.onClick.AddListener(QuitGame);    
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
