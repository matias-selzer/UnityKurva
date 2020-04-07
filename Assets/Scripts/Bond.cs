using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond 
{

	public int startPos,endPos;
    private GameObject graphicBond;
    private  float size;

	public Bond (){
	}

	public Bond(int startPos,int endPos){
		this.startPos = startPos;
		this.endPos = endPos;
	}

    public GameObject GraphicBond
    {
        get
        {
            return graphicBond;
        }

        set
        {
            graphicBond = value;
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
}
