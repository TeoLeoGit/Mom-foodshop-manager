using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReportRow : MonoBehaviour
{
    [SerializeField] private TMP_InputField _fieldDay;
    [SerializeField] private TMP_InputField _fieldIncome;
    [SerializeField] private TMP_InputField _fieldExpense;
    [SerializeField] private TextMeshProUGUI _txtTotal;
    [SerializeField] private TextMeshProUGUI _txtAverage;
    [SerializeField] private Button _btnRemove;

    private DataRow _data;

    public float Income { get { return _data.income; } }
    public float Expense { get { return _data.expense; } }
    public DataRow RowValue { get { return _data; } }

    private void Awake()
    {
        MainController.OnUpdateAverage += UpdateAverage;

        _btnRemove.onClick.AddListener(RemoveRow);
    }

    private void OnDestroy()
    {
        MainController.OnUpdateAverage -= UpdateAverage;
    }

    public void SetRow(DataRow data)
    {
        _data = data;
        _fieldDay.text = data.date.ToString("d MMM yyyy");
        _fieldIncome.text = data.income.ToString();
        _fieldExpense.text = data.expense.ToString();
        _txtTotal.text = (_data.income - _data.expense).ToString();

        if (_data.income - _data.expense < 0) _txtTotal.color = new Color32(255, 0, 52, 255);
        else _txtTotal.color = new Color32(0, 142, 66, 255);

        MainController.CallUpdateAverage();
    }

    public void OnDayChange()
    {
        if (DateTime.TryParseExact(_fieldDay.text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime day))
        {
            _data.date = day;
        }
    }

    public void OnIncomeChange()
    {
        if (float.TryParse(_fieldIncome.text, out float result))
        {
            _data.income = result;
            _txtTotal.text = (_data.income - _data.expense).ToString();
            if (_data.income - _data.expense < 0) _txtTotal.color = new Color32(255, 0, 52, 255);
            else _txtTotal.color = new Color32(0, 142, 66, 255);
            MainController.CallUpdateAverage();
        }
    }

    public void OnExpenseChange()
    {
        if (float.TryParse(_fieldExpense.text, out float result))
        {
            _data.expense = result;
            _txtTotal.text = (_data.income - _data.expense).ToString();
            if (_data.income - _data.expense < 0) _txtTotal.color = new Color32(255, 0, 52, 255);
            else _txtTotal.color = new Color32(0, 142, 66, 255);
            MainController.CallUpdateAverage();
        }
    }

    public void UpdateAverage(float average)
    {
        _txtAverage.text = average.ToString();
    }

    private void RemoveRow()
    {
        MainController.RemoveRow(this);
        Destroy(this.gameObject);
    }

}
