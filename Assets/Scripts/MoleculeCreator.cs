using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleculeCreator : MonoBehaviour
{
    private List<Molecule> molecules;
    public GameObject genericAtom;
    private float generalAlpha;
    public GameObject containerPrefab;
    public GameObject billboardBond;
    private Transform container;

    public Toggle bondsToggle, hToggle;

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
        bondsToggle.isOn = true;
        hToggle.isOn = true;
    }


	public void CreateMolecule(List<Atom> atoms, List<Bond> bonds)
    {
        molecules.Add(new Molecule(atoms, bonds));
	}

    public void ShowMolecules()
    {
        generalAlpha = 1.0f / molecules.Count;
        //Debug.Log("Cantidad de moleculas " + molecules.Count);
        int i = 0;
        foreach(Molecule m in molecules)
        {
            //Debug.Log("mole: " + i++);
            ShowAtoms(m.Atoms);
            ShowBonds(m.Atoms,m.Bonds);
        }
    }

	public void ShowAtoms(List<Atom> atoms){
		for (int i = 0; i < atoms.Count; i++) {
			//Debug.Log (((Molecule)molecules [i]).getType().Equals ("C"));
			GameObject newAtom = Instantiate (genericAtom, ((Atom)atoms [i]).getPosition (), transform.rotation)as GameObject;
            //newAtom.transform.parent = container;
            ChangeAtomColor(newAtom, ((Atom)atoms[i]).getType());
            if (((Atom)atoms[i]).getType().Equals("H"))
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertHAtom(newAtom);
            }
            else
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertAtom(newAtom);
            }
            
		}
	}

    private void ChangeAtomColor(GameObject atom, string c)
    {
<<<<<<< HEAD
=======
        atomsSize = atomsSizeSlider.value;
        UpdateVisualization();
    }

    public void OnChangeBondsSizeSlider()
    {
        bondsSize = bondsSizeSlider.value;
        UpdateVisualization();
    }

    public void OnChangeDensitySlider()
    {
        if (invertOpacity)
        {
            densityFilter = densitySlider.maxValue-densitySlider.value;
        }
        else
        {
            densityFilter = densitySlider.value;
        }
        
        //matrix.AssignOpacityLevel(opacityFilter);

        UpdateVisualization();
    }

    public void OnChangeOpacitySlider()
    {
        generalOpacity = opacitySlider.value;
        UpdateVisualization();
    }

    private void ChangeAtomColor(GameObject atom, string c,float opacity)
    {
<<<<<<< HEAD
>>>>>>> parent of 4f30dd5... Dictionary for atoms types added
=======
>>>>>>> parent of 4f30dd5... Dictionary for atoms types added
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
<<<<<<< HEAD
<<<<<<< HEAD
        newColor.a = generalAlpha;
=======
=======
>>>>>>> parent of 4f30dd5... Dictionary for atoms types added
        //newColor.a = generalOpacity;
        //Debug.Log(opacity);
        newColor.a = opacity;
>>>>>>> parent of 4f30dd5... Dictionary for atoms types added
        atom.GetComponent<MeshRenderer>().material.color = newColor;
    }

	public void ShowBonds(List<Atom> atoms, List<Bond> bonds)
    {
		for (int i = 0; i < bonds.Count; i++) {
            Atom start = ((Atom)atoms[((Bond)bonds[i]).startPos - 1]);
            Atom end = ((Atom)atoms[((Bond)bonds[i]).endPos - 1]);
            GameObject newBond= SpawnBond(start.getPosition(), end.getPosition());

            if (start.getType().Equals("H") || end.getType().Equals("H"))
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertHBond(newBond);
            }
            else
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertBond(newBond);
            }
        }
	}

    GameObject SpawnBond(Vector3 startPos, Vector3 endPos)
    {
        GameObject newBond = Instantiate(billboardBond) as GameObject;

        //LO DEJO POR LAS DUDAS

        //Vector3 centerPos = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y) / 2;
        //newBond.transform.parent = container.transform;

        /*float scaleX = Mathf.Abs(startPos.x - endPos.x);
        float scaleY = Mathf.Abs(startPos.y - endPos.y);

        centerPos.x -= 0.5f;
        centerPos.y += 0.5f;
        newBond.transform.position = centerPos;
        newBond.transform.localScale = new Vector3(scaleX, scaleY, 1);
        */

        /*Vector3 between = endPos - startPos;
        float distance = between.magnitude;
        newBond.transform.localScale = new Vector3(between.x, between.y, between.z);
        newBond.transform.position = startPos + (between / 2.0f);
        newBond.transform.LookAt(endPos);

        Color c = newBond.GetComponent<MeshRenderer>().material.color;
        c.a = generalAlpha;
        newBond.GetComponent<MeshRenderer>().material.color = c;

        newBond.transform.parent = container.transform;*/


        newBond.transform.position = (endPos + startPos) / 2.0F;

        // Rotation
        Vector3 dirV = Vector3.Normalize(endPos - startPos);

        Vector3 rotAxisV = dirV + new Vector3(0,1,0);

        rotAxisV = Vector3.Normalize(rotAxisV);

        newBond.transform.rotation = new Quaternion(rotAxisV.x, rotAxisV.y, rotAxisV.z, 0);

        // Scale        
        float dist = Vector3.Distance(endPos, startPos);

        newBond.transform.localScale = new Vector3(0.3f, dist / 2, 0.3f);

        Color c = newBond.GetComponent<MeshRenderer>().material.color;
        c.a = generalAlpha;
        newBond.GetComponent<MeshRenderer>().material.color = c;

        //newBond.transform.parent = container.transform;
        return newBond;
    }


    public void ToggleBonds()
    {
        container.GetComponent<MoleculsGraphicContainer>().ToggleBonds(bondsToggle.isOn);
    }

    public void ToggleHAtoms()
    {
        container.GetComponent<MoleculsGraphicContainer>().ToggleHAtoms(hToggle.isOn);
    }

}
