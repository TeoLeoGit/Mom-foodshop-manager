using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField] private ReportRow _rowPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Button _btnAddNewRow;

    private void Awake()
    {
        MainController.OnAddRow += AddNewRow;
        _btnAddNewRow.onClick.AddListener(OnCallAddNewRow);
    }

    private void OnDestroy()
    {
        MainController.OnAddRow -= AddNewRow;
    }

    private void Start()
    {
    }

    public void OnCallAddNewRow()
    {
        MainController.OpenPopup(EPopup.PopupAddRow);
    }

    public void AddNewRow(DataRow dataRow)
    {
        var row = Instantiate(_rowPrefab, _container);
        row.SetRow(dataRow);
    }
}
