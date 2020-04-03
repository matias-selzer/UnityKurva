using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDFBonds
{
    private string[] data;

    public SDFBonds(string[] lines, int init, int count)
    {
        data = new string[count];
        for (int i = 0; i < count; i++)
        {
            data[i] = lines[i + init];
        }
        //Debug.Log("cant bonds: " + data.Length);
    }

    public string[] GetBondLine(int pos)
    {

        string[] toReturn= data[pos].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //Debug.Log("bonds antes: " + toReturn[0] + "-" + toReturn[1]);
        toReturn = SplitMergedNumbers(toReturn);
        //Debug.Log("bonds despues: " + toReturn[0] + "-" + toReturn[1]);
        return toReturn;
    }

    public string[] Data
    {
        get
        {
            return data;
        }
    }

    private string[] SplitMergedNumbers(string[] data)
    {
        string[] newData;
        if (data[0].Length > 3)
        {
            newData = new string[data.Length + 1];
            string first;
            string second;
            if (data[0].Length == 4)
            {
                first = data[0].Substring(0, 1);
                second = data[0].Substring(1);
            }
            else if (data[0].Length == 5)
            {
                first = data[0].Substring(0, 2);
                second = data[0].Substring(2);
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
