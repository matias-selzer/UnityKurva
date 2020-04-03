using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDFDefinitionLine 
{
    private string[] data;

    public SDFDefinitionLine(string line)
    {
        data = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        data = SplitMergedNumbers(data);
        //Debug.Log(data[0]+" - "+data[1]);
    }

    public int GetCantAtoms()
    {
        return int.Parse(data[0]);
    }

    public int GetCantBonds()
    {
        return int.Parse(data[1]);
    }

    private string[] SplitMergedNumbers(string[] data)
    {
        string[] newData;
        if (data[0].Length > 4)
        {
            newData = new string[data.Length + 1];
            string first;
            string second;
            if (data[0].Length == 5)
            {
                first = data[0].Substring(0, 2);
                second= data[0].Substring(2);
            }
            else
            {
                first = data[0].Substring(0, 3);
                second = data[0].Substring(3);
            }
            newData[0] = first;
            newData[1] = second;
            for (int i = 1; i < data.Length; i++)
            {
                newData[i + 1] = data[i];
            }
        }
        else
        {
            newData = data;
        }
        return newData;
    }
}
