using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualOxygen: VisualAtom
{ //default values
    protected static Color defaultColor = Color.red;

    public VisualOxygen(Vector3 position) : base(position)
    {
        visualObject.GetComponent<Renderer>().material.color = defaultColor;
    }

}
