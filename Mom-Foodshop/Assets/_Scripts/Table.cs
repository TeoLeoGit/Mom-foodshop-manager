using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField] private ReportRow _rowPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Button _btnAddNewRow;
    [SerializeField] private TextMeshProUGUI _txtSum;

    private List<ReportRow> _rowList = new();

    private void Awake()
    {
        MainController.OnAddRow += AddNewRow;
        MainController.OnCallUpdateAverage += UpdateAverage;
        MainController.OnRemoveRow += OnRemoveRow;

        _btnAddNewRow.onClick.AddListener(OnCallAddNewRow);
    }

    private void OnDestroy()
    {
        MainController.OnAddRow -= AddNewRow;
        MainController.OnCallUpdateAverage -= UpdateAverage;
        MainController.OnRemoveRow -= OnRemoveRow;
    }

    private void Start()
    {
        var data = MainModel.ReadFromeFile();
        foreach(var row in data)
            AddNewRow(row);
    }

    public void OnCallAddNewRow()
    {
        MainController.OpenPopup(EPopup.PopupAddRow);
    }

    public void AddNewRow(DataRow dataRow)
    {
        var row = Instantiate(_rowPrefab, _container);
        _rowList.Add(row);
        row.SetRow(dataRow);
    }

    private void UpdateAverage()
    {
        List<float> totals = new();
        float sum = 0;
        foreach(var row in _rowList)
        {
            totals.Add(row.Income - row.Expense);
            sum += totals.Last();
        }
        MainController.UpdateAverage(Utils.CalculateAverage(totals));
        _txtSum.text = sum.ToString();
        Save();
    }

    private void OnRemoveRow(ReportRow row)
    {
        var removeIndex = _rowList.FindIndex(item => item == row);
        if (removeIndex > -1)
        {
            _rowList.RemoveAt(removeIndex);
        }
        UpdateAverage();
    }

    private void Save()
    {
        List<DataRow> data = new List<DataRow>();
        foreach(var row in _rowList)
        {
            data.Add(row.RowValue);
        }
        MainController.SaveData(data);
    }
}
