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
    private static string _fileName = "data";
    public static int Month { get { return _month; } }
    public static int Year { get { return _year; } }
    public static string FileName { get { return _fileName; } }


    public static void SetMonth(int month)
    {
        _month = month;
    }

    public static void SetYear(int year)
    {
        _year = year;
    }

    public static void SetFileName(string fileName)
    {
        _fileName = fileName;
    }

    public static void WriteReportToFile(List<DataRow> data)
    {
        string jsonData = JsonHelper.ToJson(data.ToArray());
        File.WriteAllText(Application.dataPath + $"/{_fileName}.json", jsonData);
    }

    public static List<DataRow> ReadFromeFile()
    {
        if (File.Exists(Application.dataPath + $"/{_fileName}.json"))
        {
            string jsonData = File.ReadAllText(Application.dataPath + $"/{_fileName}.json");
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
