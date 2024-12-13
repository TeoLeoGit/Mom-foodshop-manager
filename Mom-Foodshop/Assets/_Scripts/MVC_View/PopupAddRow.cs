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
        if (float.TryParse(_fieldIncome.text, out float income))
        {
            if (float.TryParse(_fieldExpense.text, out float expense))
            {
                if (DateTime.TryParseExact(_fieldDay.text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime day))
                {
                    var rowData = new DataRow(day, income, expense);
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
