using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VisualAtom : VisualItem
{ //default values
    protected static Vector3 defaultSize = Vector3.one*0.7f;

    public VisualAtom(Vector3 position){
        visualObject=GameObject.Find("Manager").GetComponent<GraphicsCreator>().createBasicSphere();
       // visualObject = GraphicsCreator.getInstance().createBasicSphere();
        visualObject.transform.position = position;
        visualObject.transform.localScale = defaultSize;
    } 



}
