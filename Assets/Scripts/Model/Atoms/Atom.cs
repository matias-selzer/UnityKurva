using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Atom
{
	private Vector3 position;
	private float size;
	private Color color;
	private float opacity;

	public Atom (Vector3 pos){
		position=pos;
		size = 1.0f;
		color = Color.grey;
		opacity = 1.0f;
	}

	public Vector3 getPosition(){
		return position;
	}

}