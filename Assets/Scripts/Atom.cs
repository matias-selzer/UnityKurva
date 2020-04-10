using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom
{

	private Vector3 position;
	private string type;

	public Atom(float x ,float y, float z, string t){
		position.x = x;
		position.y = y;
		position.z = z;
		type = t;
	}

	public Vector3 getPosition(){
		return position;
	}

	public string getType(){
		return type;
	}

    
}
