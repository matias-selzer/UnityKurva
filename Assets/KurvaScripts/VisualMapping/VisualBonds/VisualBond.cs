using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBond : VisualItem
{ //default values

    public static Color defaultColor = Color.blue;

    public VisualBond(Vector3 initPos, Vector3 endPos)
    {
        visualObject = GraphicsCreator.getInstance().createBasicCylinder();
        Vector3 scaleAux = visualObject.transform.localScale;
        scaleAux.y = Vector3.Distance(initPos, endPos) / 2;
        scaleAux.x = 0.2f;
        scaleAux.z = 0.2f;
        visualObject.transform.localScale = scaleAux;

        Vector3 pos = Vector3.Lerp(initPos, endPos, (float)0.5);
        visualObject.transform.position = pos;
        visualObject.transform.up = endPos - initPos;
    }

   



}
