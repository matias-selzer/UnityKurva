using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeCreator : MonoBehaviour
{

	public GameObject catom,hatom;
	public Line line;
	public Material lineMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }


	public void createMolecule(ArrayList atoms,ArrayList bonds){
		//showAtoms (atoms);
		//showBonds (atoms,bonds);
		Molecule newMolecule = new Molecule(atoms,bonds);
		//agregar al moleculesManager
	}

	/*
	public void showAtoms(ArrayList atoms){
		for (int i = 0; i < atoms.Count; i++) {
			//Debug.Log (((Molecule)molecules [i]).getType().Equals ("C"));
			if (((Atom)atoms [i]).getType().Equals ("C")) {
				Instantiate (catom, ((Atom)atoms [i]).getPosition (), transform.rotation);
			} else {
				Instantiate (hatom, ((Atom)atoms [i]).getPosition (), transform.rotation);
			}
		}


	}

	public void showBonds(ArrayList atoms,ArrayList bonds){
		for (int i = 0; i < bonds.Count; i++) {
			Line l = Instantiate (line) as Line;
			//Debug.Log (i);
			//Debug.Log(((Bond)bonds [i]).startPos);
			l.startingPoint = ((Atom)atoms [((Bond)bonds [i]).startPos-1]).getPosition ();
			l.endPoint=((Atom)atoms [((Bond)bonds [i]).endPos-1]).getPosition ();
			l.LineMaterial = lineMaterial;

			l.SetupLine ();
		}
	}
*/

}
