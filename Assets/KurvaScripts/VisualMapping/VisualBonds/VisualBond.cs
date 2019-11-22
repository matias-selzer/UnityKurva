using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBond : VisualItem
{ //default values

    public static Color defaultColor = Color.blue;

    public VisualBond(Vector3 initPos, Vector3 endPos)
    {
        visualObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        
    }



}
