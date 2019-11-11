﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class MoleculesCreatorFromSDF : MoleculesCreator
{
	private string sdfData;
	private string[] dataLines;
	private int pos;
	private ArrayList newMolecules;

	public MoleculesCreatorFromSDF(string data){
		sdfData=data;
	}

	public override ArrayList generateMolecules(){
		newMolecules = new ArrayList();

		sdfData = deleteMultipleSpaces (sdfData);
		pos=0;
		dataLines = getSeparateLines (sdfData);
		parseData ();

		return newMolecules;
	}


	string deleteMultipleSpaces(string d){
		RegexOptions options = RegexOptions.None;
		Regex regex = new Regex ("[ ]{2,}", options);    
		return regex.Replace(d, " ");
	}

	string[] getSeparateLines(string input){
		return input.Split(new string[] { "\\n" }, StringSplitOptions.None);
	}

	void parseData(){
		ArrayList atoms = new ArrayList ();
		ArrayList bonds = new ArrayList ();
		while (!reachEndOfFile()) {
			string[] line = getElementsOfSingleLine(); 
			if (isAtomsLine(line)) {
				Atom a = AtomsFactory.getInstance().createAtom(new Vector3(float.Parse (line [1]), float.Parse (line [2]), float.Parse (line [3])),line [4]);
				//Atom a = new Atom (float.Parse (line [1]), float.Parse (line [2]), float.Parse (line [3]), line [4]);
				atoms.Add (a);
			} else if (isBondsLine(line)) {
				Bond b = new Bond (int.Parse (line [1]), int.Parse (line [2]));
				bonds.Add (b);
			} else if (isEndOfMolecule(line) || reachEndOfFile()) {
				createMolecule (atoms, bonds);
				atoms = new ArrayList ();
				bonds = new ArrayList ();
			}
			pos++;
		}
	}

	bool isEndOfMolecule(string[] line){
		return line[0].Equals("$$$$");
	}

	bool isAtomsLine(string[] line){
		return line.Length == 17;
	}

	bool isBondsLine(string[] line){
		return line.Length == 5;
	}

	string[] getElementsOfSingleLine(){
		return dataLines [pos].Split (' ');
	}

	private bool reachEndOfFile(){
		return pos >= dataLines.Length-1;
	}

	void createMolecule(ArrayList atoms,ArrayList bonds){
		newMolecules.Add(new Molecule(atoms,bonds));

	}


}