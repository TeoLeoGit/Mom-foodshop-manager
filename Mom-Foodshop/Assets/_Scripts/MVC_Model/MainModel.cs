using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MainModel
{
    private static int _month;
    private static int _year;
    public static int Month { get { return _month; } }
    public static int Year { get { return _year; } }

    public static void SetMonth(int month)
    {
        _month = month;
    }

    public static void SetYear(int year)
    {
        _year = year;
    }

    public static void WriteReportToFile(List<DataRow> data)
    {
        string jsonData = JsonHelper.ToJson(data.ToArray());
        File.WriteAllText(Application.dataPath + "/data.json", jsonData);
    }

    public static List<DataRow> ReadFromeFile()
    {
        if (File.Exists(Application.dataPath + "/data.json"))
        {
            string jsonData = File.ReadAllText(Application.dataPath + "/data.json");
            var data = JsonHelper.FromJson<DataRow>(jsonData).ToList();
            foreach(var row in data)
            {
                row.date = DateTime.Parse(row.dateInString);
            }
            return data;
        }
        return null;
    }
}
