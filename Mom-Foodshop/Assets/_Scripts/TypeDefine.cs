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

    public DataRow(DateTime date, float income, float expense)
    {
        this.date = date;
        this.income = income;
        this.expense = expense;
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
