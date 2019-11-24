using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisualHydrogen : VisualAtom
{ //default values
    protected static Color defaultColor = Color.white;

    public VisualHydrogen(Vector3 position) : base(position)
    {
        visualObject.GetComponent<Renderer>().material.color = defaultColor;
    }

}
