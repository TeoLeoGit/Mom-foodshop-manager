using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MainModel
{
    public static void WriteReportToFile(List<DataRow> data)
    {
        // Convert data to JSON string
        string jsonData = JsonHelper.ToJson(data.ToArray());
        Debug.Log(jsonData);

        // Write JSON data to a file
        File.WriteAllText(Application.dataPath + "/data.json", jsonData);
    }

    public static List<DataRow> ReadFromeFile()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/data.json");
        return JsonHelper.FromJson<DataRow>(jsonData).ToList();
    }
}
