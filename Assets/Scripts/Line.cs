using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

	public Vector3 startingPoint,endPoint;
	public Material LineMaterial;


	public void SetupLine()
	{
		LineRenderer line = GetComponent<LineRenderer> ();
		line.sortingLayerName = "OnTop";
		line.sortingOrder = 5;
		line.SetVertexCount(2);
		line.SetPosition(0, startingPoint);
		//line.SetPosition(1, middlePoint);
		line.SetPosition(1, endPoint);
		line.SetWidth(0.3f, 0.3f);
		line.useWorldSpace = true;
		line.material = LineMaterial;
	}
}
