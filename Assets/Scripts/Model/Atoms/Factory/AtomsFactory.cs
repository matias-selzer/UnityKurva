﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomsFactory 
{

	private AtomsFactory(){}

	private static AtomsFactory instance = new AtomsFactory();

	public static AtomsFactory getInstance(){
		return instance;
	}

	public Atom createAtom(Vector3 position,string type){
		Atom newAtom;
		if(type.Equals("N")){
			newAtom=new Carbon(position);
		}else if(type.Equals("O")){
			newAtom=new Carbon(position);
		}else if(type.Equals("H")){
			newAtom=new Carbon(position);
		}else{
			newAtom=new Carbon(position);
		}
		return newAtom;
	}
}
