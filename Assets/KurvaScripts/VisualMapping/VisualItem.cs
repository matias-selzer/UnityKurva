using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VisualItem
{
    protected DataItem dataItem;
    protected GameObject visualObject;

    public DataItem GetDataItem() {
        return dataItem;
    }
    
}
