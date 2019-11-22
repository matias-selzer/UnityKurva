using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDFdata : MoleculesData
{
    protected string data;
    public SDFdata(string data)
    {
        this.data = data;
    }

    public override string getStringData()
    {
        return data;
    }
}
