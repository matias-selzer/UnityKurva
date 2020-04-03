using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintPositions : MonoBehaviour
{
    public GameObject container;

    // Start is called before the first frame update
    void Start()
    {
        PrintAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrintAll()
    {
        string salida = "";
        for(int i = 0; i < container.transform.childCount; i++)
        {
            Vector3 childPos = container.transform.GetChild(i).position;
            salida += childPos.x + " " + childPos.y + " " + childPos.z + " O   0  0  0  0  0  0  0  0  0  0  0  0\n";
        }

        Debug.Log(salida);
    }
}
