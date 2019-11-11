using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculesManager
{
	private MoleculesRepository repository;

	public MoleculesManager(){
		repository = new MoleculesRepository();
	}


	public void addMolecule(Molecule m){
		repository.addMolecule(m);
	}

	public void createMoleculesFromSDFFile(string data){
		ArrayList newMolecules= new MoleculesCreatorFromSDF(data).generateMolecules();
		repository.addMolecules(newMolecules);
	}


}
