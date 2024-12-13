using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static float CalculateAverage(List<float> incomeList)
    {
        if (incomeList.Count == 0) return 0;
        float total = 0;
        foreach(var income in incomeList)
        {
            total += income;
        }
        return total / incomeList.Count;
    }
}
