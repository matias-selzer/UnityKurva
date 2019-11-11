using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculesRepository {

	private ArrayList molecules;

	public MoleculesRepository(){
		molecules=new ArrayList();
	}

	public void addMolecule(Molecule m){
		molecules.Add(m);
	}

	public void addMolecules(ArrayList mols){
		for(int i=0;i<mols.Count;i++){
			addMolecule((Molecule)mols[i]);
		}
	}

}
