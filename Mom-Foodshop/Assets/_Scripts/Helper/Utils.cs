using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static float calculateAverage(List<float> incomeList)
    {
        float total = 0;
        foreach(var income in incomeList)
        {
            total += income;
        }
        return total / incomeList.Count;
    }
}
