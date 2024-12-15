using System;
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
    [SerializeField] private TextMeshProUGUI _txtSumTotal;
    [SerializeField] private TextMeshProUGUI _txtSumIncome;
    [SerializeField] private TextMeshProUGUI _txtSumExpense;
    [SerializeField] private TMP_InputField _inputMonth;
    [SerializeField] private TMP_InputField _inputYear;


    private List<ReportRow> _rowList = new();

    private void Awake()
    {
        MainController.OnAddRow += AddNewRow;
        MainController.OnCallUpdateAverage += UpdateAverage;
        MainController.OnRemoveRow += OnRemoveRow;
        MainController.OnCallSortTable += SortByDate;
        MainController.OnChangeFile += OnChangeFile;

        _btnAddNewRow.onClick.AddListener(OnCallAddNewRow);
    }

    private void OnDestroy()
    {
        MainController.OnAddRow -= AddNewRow;
        MainController.OnCallUpdateAverage -= UpdateAverage;
        MainController.OnRemoveRow -= OnRemoveRow;
        MainController.OnCallSortTable -= SortByDate;
        MainController.OnChangeFile -= OnChangeFile;
    }

    private void Start()
    {
        var data = MainModel.ReadFromeFile();
        if (data == null) return;
        foreach(var row in data)
            AddNewRow(row);
        SortByDate();
        Save();
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
        SortByDate();
    }

    public void SetMonth()
    {
        if (int.TryParse(_inputMonth.text, out int result))
        {
            MainController.SetMonth(result);
        }
    }

    public void SetYear()
    {
        if (int.TryParse(_inputYear.text, out int result))
        {
            MainController.SetYear(result);
        }
    }

    private void UpdateAverage()
    {
        List<float> totals = new();
        float sumTotal = 0;
        float sumIncome = 0;
        float sumExpense = 0;

        foreach (var row in _rowList)
        {
            totals.Add(row.Income - row.Expense);
            sumIncome += row.Income;
            sumExpense += row.Expense;
            sumTotal += totals.Last();
        }
        MainController.UpdateAverage(Utils.CalculateAverage(totals));
        _txtSumTotal.text = sumTotal.ToString();
        _txtSumIncome.text = sumIncome.ToString();
        _txtSumExpense.text = sumExpense.ToString();

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

    private void SortByDate()
    {
        _rowList.Sort((x, y) => x.RowValue.date.CompareTo(y.RowValue.date));
        var index = 0;
        foreach (var row in _rowList)
        {
            row.transform.SetSiblingIndex(index);
            index++;
        }
    }

    private void OnChangeFile()
    {
        foreach (Transform child in _container.transform)
            Destroy(child.gameObject);
        _rowList = new();
        var data = MainModel.ReadFromeFile();
        if (data == null) return;
        foreach (var row in data)
            AddNewRow(row);
        SortByDate();
        Save();
    }
}
