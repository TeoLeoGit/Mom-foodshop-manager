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
        _btnClose.onClick.AddListener(MainController.HideAllPopup);
    }

    public void AddRow()
    {
        var month = MainModel.Month < 10 ? $"0{MainModel.Month}" : $"{MainModel.Month}";
        var day = _fieldDay.text.Length > 1 ? _fieldDay.text : $"0{_fieldDay.text}";
        if (float.TryParse(_fieldIncome.text, out float income))
        {
            if (float.TryParse(_fieldExpense.text, out float expense))
            {
                if (DateTime.TryParseExact($"{day}/{month}/{MainModel.Year}", "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    var rowData = new DataRow(date, income, expense);
                    MainController.AddNewRow(rowData);
                }
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
