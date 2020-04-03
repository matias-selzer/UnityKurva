using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class sdfReaderMultiple : MonoBehaviour
{
	public string data;

	void Start(){
        //Debug.Log(data);
        data = deleteMultipleSpaces (data);
        Debug.Log(data);
		string[] dataLines = getSeparateLines (data);
        Debug.Log(data.Length);
		//interpreteSingleMolecule (dataLines, 0);
	}

	/*void Start(){
		#if !UNITY_EDITOR && UNITY_WEBGL
		WebGLInput.captureAllKeyboardInput = false;
		#endif
	}*/

	public void interpretData(string data){
		data = deleteMultipleSpaces (data);
		string[] dataLines = getSeparateLines (data);
		interpreteSingleMolecule (dataLines, 0);
	}

	string deleteMultipleSpaces(string d){
		RegexOptions options = RegexOptions.None;
		Regex regex = new Regex ("[ ]{2,}", options);    
		return regex.Replace(d, " ");
	}

	string[] getSeparateLines(string input){
		return input.Split(new string[] { "\\n" }, StringSplitOptions.None);
	}

	void interpreteSingleMolecule(string[] dataLines,int pos){
		ArrayList atoms = new ArrayList ();
		ArrayList bonds = new ArrayList ();
		bool endMolecule = false;
		while (!endMolecule) {
			string[] line = dataLines [pos].Split (' ');
			if (line.Length == 17) {
				Atom a = new Atom (float.Parse (line [1]), float.Parse (line [2]), float.Parse (line [3]), line [4]);
				atoms.Add (a);
			} else if (line.Length == 5) {
				Bond b = new Bond (int.Parse (line [1]), int.Parse (line [2]));
				bonds.Add (b);
			} else if (line[0].Equals("$$$$") || pos>=dataLines.Length-1) {
				createMolecule (atoms, bonds);
				atoms = new ArrayList ();
				bonds = new ArrayList ();
			}
			endMolecule = pos >= dataLines.Length-1;
			pos++;
		}
	}

	void createMolecule(ArrayList atoms,ArrayList bonds){
		//GetComponent<MoleculeCreator>().CreateMolecule (atoms, bonds);
	}




}
