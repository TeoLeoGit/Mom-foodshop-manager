using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController
{
    public static event Action OnCallAddRow;
    public static event Action<DataRow> OnAddRow;
    public static event Action<EPopup> OnOpenPopup;

    public static void OpenPopupAddRow()
    {
        OnCallAddRow?.Invoke();
    }

    public static void AddNewRow(DataRow row)
    {
        OnAddRow?.Invoke(row);
    }

    public static void OpenPopup(EPopup type)
    {
        OnOpenPopup?.Invoke(type);
    }
}
