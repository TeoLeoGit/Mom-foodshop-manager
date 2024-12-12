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
    [SerializeField] private TextMeshProUGUI _txtAverage;
    private int _id;

    public void SetRow(DataRow data)
    {
        _id = data.id;
        _fieldDay.text = data.date.ToString();
        _fieldIncome.text = data.income.ToString();
        _fieldExpense.text = data.expense.ToString();
        _txtAverage.text = data.average.ToString();
    }

    public void OnDayChange()
    {
        //call event.
        Debug.Log("osd1");
        Debug.Log(_fieldDay.text);

    }

    public void OnIncomeChange()
    {
        //call event.
        Debug.Log("osd2");
        Debug.Log(_fieldIncome.text);
    }

    public void OnExpenseChange()
    {
        //call event.
        Debug.Log("osd3");
        Debug.Log(_fieldExpense.text);

    }
}
