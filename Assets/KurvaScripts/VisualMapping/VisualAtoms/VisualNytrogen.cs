using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNytrogen : VisualAtom
{ //default values
    protected static Color defaultColor = Color.blue;

    public VisualNytrogen(Vector3 position) : base(position)
    {
        visualObject.GetComponent<Renderer>().material.color = defaultColor;
    }

}
