using System;
using System.Collections.Generic;

public class MainController
{
    public static event Action<DataRow> OnAddRow;
    public static event Action<EPopup> OnOpenPopup;
    public static event Action OnHideAllPopup;
    public static event Action OnCallUpdateAverage;
    public static event Action<float> OnUpdateAverage;
    public static event Action<ReportRow> OnRemoveRow;
    public static event Action OnCallSortTable;

    public static void AddNewRow(DataRow row)
    {
        OnAddRow?.Invoke(row);
    }

    public static void OpenPopup(EPopup type)
    {
        OnOpenPopup?.Invoke(type);
    }

    public static void HideAllPopup()
    {
        OnHideAllPopup?.Invoke();
    }

    public static void CallUpdateAverage()
    {
        OnCallUpdateAverage?.Invoke();
    }

    public static void UpdateAverage(float average)
    {
        OnUpdateAverage?.Invoke(average);
    }

    public static void RemoveRow(ReportRow row)
    {
        OnRemoveRow?.Invoke(row);
    }

    public static void SaveData(List<DataRow> data)
    {
        MainModel.WriteReportToFile(data);
    }

    public static void SetMonth(int month)
    {
        MainModel.SetMonth(month);
    }

    public static void SetYear(int year)
    {
        MainModel.SetYear(year);
    }

    public static void CallSortTable()
    {
        OnCallSortTable?.Invoke();
    }
}
