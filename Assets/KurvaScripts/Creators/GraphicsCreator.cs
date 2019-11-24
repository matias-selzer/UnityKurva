using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsCreator : MonoBehaviour
{
    public GameObject basicSphere,basicCylinder;
    /*
    private GraphicsCreator() { }

    private static GraphicsCreator instance;

    public static GraphicsCreator getInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = GetComponent<GraphicsCreator>();
    }*/

    public GameObject createBasicSphere()
    {
        return Instantiate(basicSphere) as GameObject;
    }

    public GameObject createBasicCylinder()
    {
        return Instantiate(basicCylinder) as GameObject;
    }

}
