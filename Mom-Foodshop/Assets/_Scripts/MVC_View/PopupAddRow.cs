using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupAddRow : MonoBehaviour, IPopup
{
    [SerializeField] private TMP_InputField _fieldDay;
    [SerializeField] private TMP_InputField _fieldIncome;
    [SerializeField] private TMP_InputField _fieldExpense;
    [SerializeField] private Button _btnAdd;
    [SerializeField] private Button _btnClose;

    private void Awake()
    {
        _btnAdd.onClick.AddListener(AddRow);
    }

    public void AddRow()
    {
        if (float.TryParse(_fieldIncome.text, out float income))
        {
            Debug.Log(income);
            if (float.TryParse(_fieldIncome.text, out float expense))
            {
                Debug.Log(expense);
                if (DateTime.TryParseExact(_fieldDay.text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime day))
                {
                    Debug.Log(day);
                    var rowData = new DataRow(day, income, expense);
                    MainController.AddNewRow(rowData);
                }
            }
        } 
    }

    public void Show()
    {
    }

    public void Hide()
    {
    }
}
