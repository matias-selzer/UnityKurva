using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom
{

	private Vector3 position;
	private string type;
    private float opacity;
    private GameObject graphicAtom;
    private float size;
    private float density;

    public GameObject GraphicAtom
    {
        get
        {
            return graphicAtom;
        }

        set
        {
            graphicAtom = value;
        }
    }

    public float Size
    {
        get
        {
            return size;
        }

        set
        {
            size = value;
        }
    }

    public float Density
    {
        get
        {
            return density;
        }

        set
        {
            density = value;
        }
    }


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

    public void SetOpacity(float f)
    {
        opacity = f;
    }

    public float GetOpacity()
    {
        return opacity;
    }

    
}
