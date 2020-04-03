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
        Debug.Log("cant bonds: " + data.Length);
    }
}
