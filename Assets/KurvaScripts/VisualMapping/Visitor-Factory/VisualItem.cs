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

    public void changeAlphaColor(float alpha)
    {
        Color color = visualObject.GetComponent<Renderer>().material.color;
        color.a = alpha;
        visualObject.GetComponent<Renderer>().material.color = color;

        visualObject.GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        visualObject.GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        visualObject.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
        visualObject.GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
        visualObject.GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
        visualObject.GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        visualObject.GetComponent<Renderer>().material.renderQueue = 3000;
    }

    public Vector3 getPosition()
    {
        return visualObject.transform.position;
    }
    
}
