using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Button _btnQuit;
    [SerializeField] private TMP_InputField _inputFilename;

    private void Awake()
    {
        _btnQuit.onClick.AddListener(QuitGame);
        _inputFilename.text = MainModel.FileName;
    }

    public void ChangeFile()
    {
        MainController.ChangeSourceFile(_inputFilename.text);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
