using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeCreator : MonoBehaviour
{
    private List<Molecule> molecules;
    public GameObject genericAtom;
	public Line line;
	public Material lineMaterial;
    private float generalAlpha;
    public GameObject containerPrefab;
    private Transform container;

    // Start is called before the first frame update
    void Awake()
    {
        molecules = new List<Molecule>();
    }

    public void InitializeStructure()
    {
        if(container!=null)DestroyImmediate(container.gameObject);
        GameObject newContainer = Instantiate(containerPrefab) as GameObject;
        container = newContainer.transform;
        molecules = new List<Molecule>();
    }


	public void CreateMolecule(List<Atom> atoms, List<Bond> bonds)
    {
        molecules.Add(new Molecule(atoms, bonds));
	}

    public void ShowMolecules()
    {
        generalAlpha = 1.0f / molecules.Count;
        //Debug.Log("Cantidad de moleculas " + molecules.Count);
        foreach(Molecule m in molecules)
        {
            ShowAtoms(m.Atoms);
            ShowBonds(m.Atoms,m.Bonds);
        }
    }

	public void ShowAtoms(List<Atom> atoms){
		for (int i = 0; i < atoms.Count; i++) {
			//Debug.Log (((Molecule)molecules [i]).getType().Equals ("C"));
			GameObject newAtom = Instantiate (genericAtom, ((Atom)atoms [i]).getPosition (), transform.rotation)as GameObject;
            newAtom.transform.parent = container;
            ChangeAtomColor(newAtom, ((Atom)atoms[i]).getType());
		}
	}

    private void ChangeAtomColor(GameObject atom, string c)
    {
        Color newColor;
        if (c.Equals("H"))
        {
            newColor = Color.white;
        }else if (c.Equals("C"))
        {
            newColor = Color.black;
        }else if (c.Equals("N"))
        {
            newColor = Color.blue;
        }
        else // O 
        {
            newColor = Color.red;
        }
        newColor.a = generalAlpha;
        atom.GetComponent<MeshRenderer>().material.color = newColor;
    }

	public void ShowBonds(List<Atom> atoms, List<Bond> bonds)
    {
		for (int i = 0; i < bonds.Count; i++) {
			Line l = Instantiate (line) as Line;
            l.transform.parent = container.transform;
			l.startingPoint = ((Atom)atoms [((Bond)bonds [i]).startPos-1]).getPosition ();
			l.endPoint=((Atom)atoms [((Bond)bonds [i]).endPos-1]).getPosition ();
			l.LineMaterial = lineMaterial;
            Color c = lineMaterial.color;
            c.a = generalAlpha;
            l.LineMaterial.color = c;
			l.SetupLine ();
		}
	}
}
