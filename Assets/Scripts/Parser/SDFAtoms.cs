using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDFAtoms 
{
    private string[] data;

    public SDFAtoms(string[] lines,int init,int count)
    {
        data = new string[count];
        for(int i = 0; i < count; i++)
        {
            data[i] = lines[i + init];
        }
        //Debug.Log("cant atoms: " + data.Length);
    }

    public string[] GetAtomLine(int pos)
    {
        return data[pos].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    }

    public string[] Data
    {
        get
        {
            return data;
        }
    }
}
