using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPopup
{
    PopupAddRow = 1,
}

[Serializable]
public class DataRow
{
    public int id;
    public DateTime date;
    public float income;
    public float expense;
    public float average;
    public string dateInString;

    public DataRow(DateTime date, float income, float expense, string dateInString = null)
    {
        this.date = date;
        this.income = income;
        this.expense = expense;
        if (dateInString != null) this.dateInString = dateInString;
        else this.dateInString = date.ToString();
    }
}

[Serializable]
public class PopupMap
{
    public EPopup type;
    public GameObject popup;
}

public interface IPopup
{
    public void Show();
    public void Hide();
}
