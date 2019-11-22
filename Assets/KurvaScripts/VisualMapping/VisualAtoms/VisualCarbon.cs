using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCarbon : VisualAtom
{ //default values
    protected static Color defaultColor = Color.red;
    
    public VisualCarbon(Vector3 position) : base(position)
    {
        visualObject.GetComponent<Renderer>().material.color = defaultColor;        
    }

}
